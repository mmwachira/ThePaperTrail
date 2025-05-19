using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public AudioMixer gameMixer;
    public AudioSource startupMusicSource;
    public AudioSource gameplayMusicSource;
    public AudioSource accusationMusicSource;
    public AudioSource winSFXSource;
    public AudioSource loseSFXSource;

    public float fadeDuration = 1f;

    public static AudioManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep AudioManager across scenes if needed
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Start playing the initial music
        if (startupMusicSource != null)
        {
            startupMusicSource.loop = true; // Loop the startup music
            startupMusicSource.Play();
            SetMixerVolume("StartupMusicVolume", -20f); // Start at 80% volume
        }
        if (gameplayMusicSource != null)
        {
            gameplayMusicSource.loop = true; // Loop the gameplay music
            gameplayMusicSource.Stop();
            SetMixerVolume("GameplayMusicVolume", -80f); // Start muted (logarithmic scale)
        }
        if (accusationMusicSource != null)
        {
            accusationMusicSource.loop = true; // Loop the accusation music
            accusationMusicSource.Stop();
            SetMixerVolume("AccusationMusicVolume", -80f); // Start muted
        }
    }

    public void StartGameplayMusic()
    {
        if (startupMusicSource != null)
        {
            StartCoroutine(FadeOutAndStop(startupMusicSource, "StartupMusicVolume", fadeDuration));
        }
        if (gameplayMusicSource != null)
        {
            gameplayMusicSource.Play();
            StartCoroutine(FadeInMusic(gameplayMusicSource, "GameplayMusicVolume", fadeDuration));
        }
        if (accusationMusicSource != null && accusationMusicSource.isPlaying)
        {
            StartCoroutine(FadeOutMusic(accusationMusicSource, "AccusationMusicVolume", fadeDuration));
        }
    }

    public void PlayAccusationMusic()
    {
        if (gameplayMusicSource != null && gameplayMusicSource.isPlaying)
        {
            StartCoroutine(FadeOutMusic(gameplayMusicSource, "GameplayMusicVolume", fadeDuration));
        }
        if (accusationMusicSource != null)
        {
            accusationMusicSource.Play();
            StartCoroutine(FadeInMusic(accusationMusicSource, "AccusationMusicVolume", fadeDuration));
        }
    }

    private IEnumerator FadeOutAndStop(AudioSource audioSource, string exposedVolumeName, float duration)
    {
        float startVolume = GetCurrentVolume(exposedVolumeName);
        float currentTime = 0;
        while (currentTime < duration)
        {
            float newVolume = Mathf.Lerp(startVolume, -80f, currentTime / duration);
            SetMixerVolume(exposedVolumeName, newVolume);
            currentTime += Time.deltaTime;
            yield return null;
        }
        SetMixerVolume(exposedVolumeName, -80f);
        audioSource.Stop();
    }

    private IEnumerator FadeInMusic(AudioSource audioSource, string exposedVolumeName, float duration)
    {
        audioSource.Play();
        yield return StartCoroutine(FadeMixerGroupVolume(exposedVolumeName, -80f, -30f, duration));
    }

    private IEnumerator FadeOutMusic(AudioSource audioSource, string exposedVolumeName, float duration)
    {
        yield return StartCoroutine(FadeMixerGroupVolume(exposedVolumeName, GetCurrentVolume(exposedVolumeName), -80f, duration));
        audioSource.Stop();
    }


    public void PlayWinSound()
    {
        if (winSFXSource != null)
        {
            winSFXSource.PlayOneShot(winSFXSource.clip); // Assuming you've assigned the clip
        }
        // Optionally fade out other music
        FadeOutAllMusic();
    }

    public void PlayLoseSound()
    {
        if (loseSFXSource != null)
        {
            loseSFXSource.PlayOneShot(loseSFXSource.clip); // Assuming you've assigned the clip
        }
        // Optionally fade out other music
        FadeOutAllMusic();
    }

    public void FadeOutAllMusic(float duration = 1f)
    {
        if (startupMusicSource != null && startupMusicSource.isPlaying)
            StartCoroutine(FadeMixerGroupVolume("StartupMusicVolume", GetCurrentVolume("StartupMusicVolume"), -80f, duration));
        if (gameplayMusicSource != null && gameplayMusicSource.isPlaying)
            StartCoroutine(FadeMixerGroupVolume("GameplayMusicVolume", GetCurrentVolume("GameplayMusicVolume"), -80f, duration));
        if (accusationMusicSource != null && accusationMusicSource.isPlaying)
            StartCoroutine(FadeMixerGroupVolume("AccusationMusicVolume", GetCurrentVolume("AccusationMusicVolume"), -80f, duration));
    }

    private IEnumerator FadeMixerGroupVolume(string exposedVolumeName, float startVolume, float endVolume, float duration)
    {
        float currentTime = 0;
        while (currentTime < duration)
        {
            float newVolume = Mathf.Lerp(startVolume, endVolume, currentTime / duration);
            SetMixerVolume(exposedVolumeName, newVolume);
            currentTime += Time.deltaTime;
            yield return null;
        }
        SetMixerVolume(exposedVolumeName, endVolume);
    }

    private void SetMixerVolume(string exposedVolumeName, float volume)
    {
        if (gameMixer != null)
        {
            gameMixer.SetFloat(exposedVolumeName, volume);
        }
    }

    private float GetCurrentVolume(string exposedVolumeName)
    {
        float volume;
        gameMixer.GetFloat(exposedVolumeName, out volume);
        return volume;
    }
}
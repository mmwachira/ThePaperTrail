using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Animator frontPageAnimator;
    public Animator openNewspaperAnimator;
    public GameObject frontPage;
    public GameObject investigationBoard;
    public GameObject bioPanel;
    public GameObject[] bios;
    public GameObject deductionPanel;
    public GameObject startButton;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {

        frontPage.SetActive(true);

        StartCoroutine(ShowStartButton(2f)); // Show start button after 2 seconds
    }

    public void OpenDeductionPanel()
    {
        deductionPanel.SetActive(true);
    }


    public IEnumerator ShowStartButton(float delay)
    {
        yield return new WaitForSeconds(delay);
        startButton.SetActive(true);
    }

    public IEnumerator ShowNews(float delay)
    {
        yield return new WaitForSeconds(delay);
        investigationBoard.SetActive(true);
        frontPage.SetActive(false);
        UIManager.Instance.ShowWelcome("Welcome Detective! Please open the first newspaper of the day."); // Show welcome message
        AudioManager.Instance.StartGameplayMusic();
    }

    public void StartGame()
    {
        frontPageAnimator.SetTrigger("Minimize");
        startButton.SetActive(false);

        StartCoroutine(ShowNews(2f));

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenBio(int suspectIndex)
    {
        bioPanel.SetActive(true);
        for (int i = 0; i < bios.Length; i++)
        {
            bios[i].SetActive(i == suspectIndex); // Show only the bio in the index passed
        }
    }

    public void CloseBio()
    {
        bioPanel.SetActive(false);
        gameObject.SetActive(false);
        investigationBoard.SetActive(true);
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Animator frontPageAnimator;
    public GameObject frontPage;
    public GameObject newsPanel1;
    //public GameObject newsPanel2;
    public GameObject cluePopupPanel;
    public TMP_Text cluePopupText;
    public GameObject deductionPanel;
    public GameObject hintPanel;
    public TMP_Text hintText;
    public GameObject winPanel;
    public GameObject startButton;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        // cluePopupPanel.SetActive(false);
        // deductionPanel.SetActive(false);
        // hintPanel.SetActive(false);
        // winPanel.SetActive(false);
        frontPage.SetActive(true);

        StartCoroutine(ShowStartButton(2f)); // Show start button after 2 seconds
    }
    public void ShowCluePopup(string text)
    {
        cluePopupPanel.SetActive(true);
        cluePopupText.text = text;
    }

    public void CloseCluePopup()
    {
        cluePopupPanel.SetActive(false);
    }

    public void OpenDeductionPanel()
    {
        deductionPanel.SetActive(true);
    }

    public void ShowHint(string message)
    {
        hintText.text = message;
        hintPanel.SetActive(true);
    }

    public void ShowWin()
    {
        winPanel.SetActive(true);
    }

    public IEnumerator ShowStartButton(float delay)
    {
        yield return new WaitForSeconds(delay);
        startButton.SetActive(true);
    }

    public IEnumerator ShowNews(float delay)
    {
        yield return new WaitForSeconds(delay);
        newsPanel1.SetActive(true);
        frontPage.SetActive(false);
    }

    public void StartGame()
    {
        frontPageAnimator.SetTrigger("Minimize");
        startButton.SetActive(false);

        StartCoroutine(ShowNews(2f));


    }
}

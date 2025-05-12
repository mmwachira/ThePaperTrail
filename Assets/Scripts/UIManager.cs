using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    // public GameObject frontPage;
    // public GameObject investigationBoard;
    // public GameObject bioPanel;
    // public GameObject[] bios;
    // public GameObject deductionPanel;
    // public GameObject startButton;
    public GameObject winPanel;
    public GameObject WarningPanel;
    public TMP_Text warningText;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    // void Start()
    // {
    //     frontPage.SetActive(true);
    //     StartCoroutine(ShowStartButton(2f)); // Show start button after 2 seconds
    // }
    // public void OpenDeductionPanel()
    // {
    //     deductionPanel.SetActive(true);
    // }
    // public IEnumerator ShowStartButton(float delay)
    // {
    //     yield return new WaitForSeconds(delay);
    //     startButton.SetActive(true);
    // }
    // public IEnumerator ShowNews(float delay)
    // {
    //     yield return new WaitForSeconds(delay);
    //     investigationBoard.SetActive(true);
    //     frontPage.SetActive(false);
    // }
    // public void StartGame()
    // {
    //     frontPage.SetActive(false);
    //     startButton.SetActive(false);
    //     StartCoroutine(ShowNews(2f));
    // }
    // public void OpenBio(int suspectIndex)
    // {
    //     bioPanel.SetActive(true);
    //     bios[suspectIndex].SetActive(true);
    // }
    // public void CloseBio(int suspectIndex)
    // {
    //     bios[suspectIndex].SetActive(false);
    //     bioPanel.SetActive(false);
    // }
    // public void CloseDeductionPanel()
    // {
    //     deductionPanel.SetActive(false);
    // }
    // public void CloseInvestigationBoard()
    // {
    //     investigationBoard.SetActive(false);
    // }
    // public void CloseFrontPage()
    // {
    //     frontPage.SetActive(false);
    // }
    // public void CloseAll()
    // {
    //     frontPage.SetActive(false);
    //     investigationBoard.SetActive(false);
    //     bioPanel.SetActive(false);
    //     deductionPanel.SetActive(false);
    //     startButton.SetActive(false);
    // }
    // public void ShowFrontPage()
    // {
    //     frontPage.SetActive(true);
    // }
    // public void ShowInvestigationBoard()
    // {
    //     investigationBoard.SetActive(true);
    // }
    // public void ShowBio(int suspectIndex)
    // {
    //     bios[suspectIndex].SetActive(true);
    // }
    // public void ShowDeductionPanel()
    // {
    //     deductionPanel.SetActive(true);
    // }

    public void ShowWelcome(string message)
    {
        WarningPanel.SetActive(true);
        warningText.text = message;
        StartCoroutine(HideWelcome(4f)); // Hide after 2 seconds
    }
    private IEnumerator HideWelcome(float delay)
    {
        yield return new WaitForSeconds(delay);
        WarningPanel.SetActive(false);
    }

    public void ShowObjective(string message)
    {
        WarningPanel.SetActive(true);
        warningText.text = message;
        StartCoroutine(HideObjective(3f)); // Hide after 2 seconds
    }
    private IEnumerator HideObjective(float delay)
    {
        yield return new WaitForSeconds(delay);
        WarningPanel.SetActive(false);
    }

    public float GetWarningDuration()
    {
        return 1f; // Return the duration for hiding the warning
    }
    public void ShowWarning(string message)
    {
        WarningPanel.SetActive(true);
        warningText.text = message;
        StartCoroutine(HideWarning(1f)); // Hide after 2 seconds
    }

    private IEnumerator HideWarning(float delay)
    {
        yield return new WaitForSeconds(delay);
        WarningPanel.SetActive(false);
    }

    public void ShowWin()
    {
        winPanel.SetActive(true);
    }
}
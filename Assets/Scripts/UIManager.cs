using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject yesButton;
    public GameObject noButton;
    public GameObject winPanel;
    public TMP_Text winText;
    public GameObject WarningPanel;
    public TMP_Text warningText;
    public GameObject summaryPanel;

    public GameObject confirmButton;
    public GameObject cancelButton;
    public GameObject closeButton;

    private Coroutine welcomeCoroutine;
    private bool isWelcomeShowing = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void ShowWelcome(string message)
    {
        WarningPanel.SetActive(true);
        warningText.text = message;
        isWelcomeShowing = true;
        welcomeCoroutine = StartCoroutine(HideWelcome(3f)); // Hide after 3 seconds
    }
    private IEnumerator HideWelcome(float delay)
    {
        yield return new WaitForSeconds(delay);
        WarningPanel.SetActive(false);
        isWelcomeShowing = false;
        welcomeCoroutine = null;
    }

    public void ShowObjective(string message)
    {
        WarningPanel.SetActive(true);
        warningText.text = message;
        StartCoroutine(HideObjective(3f)); // Hide after 3 seconds
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
        StartCoroutine(HideWarning(1f)); // Hide after 1 second
    }

    private IEnumerator HideWarning(float delay)
    {
        yield return new WaitForSeconds(delay);
        WarningPanel.SetActive(false);
    }

    public void ShowWin()
    {
        winText.text = "Congratulations Detective! You've solved the mystery!";
        winPanel.SetActive(true);
    }

    public void ShowLose()
    {
        winText.text = "Haha! Better luck next time detective!\n\nTry again?";
        yesButton.SetActive(true);
        noButton.SetActive(true);
        winPanel.SetActive(true);
    }

    public void openSummary()
    {
        summaryPanel.SetActive(true);
        closeButton.SetActive(true);
        SuspectSelector.Instance.accusationResultPanel.SetActive(false);
    }

    public void CloseSummary()
    {
        summaryPanel.SetActive(false);
        closeButton.SetActive(false);
        SuspectSelector.Instance.accusationResultPanel.SetActive(true);

    }

    public void OnNewspaperOpened()
    {
        if (isWelcomeShowing && welcomeCoroutine != null)
        {
            StopCoroutine(welcomeCoroutine);
            isWelcomeShowing = false;
            welcomeCoroutine = null;
            ShowWelcome("Read the newspaper carefully to find clues!");
        }
    }
}
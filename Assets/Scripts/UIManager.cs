using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

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
    public TMP_Text summaryText;
    public Image summaryImage;
    public GameObject finalCulpritSummaryPanel;

    public GameObject confirmButton;
    public GameObject cancelButton;
    public GameObject closeButton;

    private Coroutine welcomeCoroutine;
    private bool isWelcomeShowing = false;
    private bool tutorialComplete = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowWarningMessage(string message, float duration = 3f)
    {
        if (welcomeCoroutine != null)
        {
            StopCoroutine(welcomeCoroutine);
        }

        WarningPanel.SetActive(true);
        warningText.text = message;
        welcomeCoroutine = StartCoroutine(HideWarning(duration));
    }

    private IEnumerator HideWarning(float delay)
    {
        yield return new WaitForSeconds(delay);
        WarningPanel.SetActive(false);
        welcomeCoroutine = null;
    }

    public void ShowWelcome(string message)
    {
        ShowWarningMessage(message, 3f); // Hide after 3 seconds
    }
    // private IEnumerator HideWelcome(float delay)
    // {
    //     HideWarning(delay);
    // }

    public void ShowTutorial(string message)
    {
        ShowWarningMessage(message, 3f); // Hide after 3 seconds
    }
    // private IEnumerator HideTutorial(float delay)
    // {
    //     HideWarning(delay);

    // }

    public void ShowObjective(string message)
    {
        ShowWarningMessage(message, 3f); // Hide after 3 seconds
    }
    // private IEnumerator HideObjective(float delay)
    // {
    //     HideWarning(delay);
    // }

    public float GetWarningDuration()
    {
        return 1f; // Return the duration for hiding the warning
    }
    public void ShowWarning(string message)
    {
        ShowWarningMessage(message, 1f); // Hide after 1 second
    }

    // private IEnumerator HideWarning(float delay)
    // {
    //     yield return new WaitForSeconds(delay);
    //     WarningPanel.SetActive(false);
    // }

    public void ShowWin()
    {
        winText.text = "Congratulations Detective! You've solved the mystery!";
        winPanel.SetActive(true);
    }

    public void ShowLose()
    {
        if (winText == null || winPanel == null) return; // Safety check to avoid null reference errors
        winText.text = "Haha! Better luck next time detective!\n\nTry again?";
        yesButton?.SetActive(true);
        noButton?.SetActive(true);
        winPanel.SetActive(true);
    }

    public void OpenSummary()
    {
        Suspect accused = SuspectSelector.Instance?.GetLastAccusedSuspect();
        if (accused == null)
        {
            Debug.LogError("No suspect was accused. Cannot open summary.");
            return;
        }

        summaryPanel.SetActive(true);
        summaryImage.sprite = accused.suspectImage;
        summaryText.text = accused.suspectSummary;
        Image culpritImage = finalCulpritSummaryPanel.GetComponent<Image>();
        if (culpritImage != null)
        {
            culpritImage.color = accused.suspectColor;
        }
        closeButton.SetActive(true);
    }

    public void CloseSummary()
    {
        summaryPanel.SetActive(false);
        closeButton.SetActive(false);
        SuspectSelector.Instance.accusationResultPanel.SetActive(true);

    }

    public void OnNewspaperOpened()
    {
        if (!tutorialComplete)
        {
            ShowTutorial("Read the newspapers carefully to find clues!\n Zoom in using the scroll wheel or pinch to zoom.");
        }
        else
        {
            return; // Do nothing if the tutorial is complete
        }

    }

    public void OnNewspaperClosed()
    {
        if (!tutorialComplete)
        {
            // If the tutorial is not complete, show the welcome message again
            ShowTutorial("Click on the portraits to learn more about the suspects.");
            tutorialComplete = true; // Mark the tutorial as complete
        }
        else if (tutorialComplete)
        {
            return; // Do nothing if the tutorial is complete
        }
    }

}
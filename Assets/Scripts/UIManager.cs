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

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

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
        GameManager.Instance.openNewspaperAnimator.SetTrigger("Open");
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
}
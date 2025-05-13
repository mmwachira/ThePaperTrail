using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SuspectSelector : MonoBehaviour
{
    public Suspect correctCulprit; // Scriptable Object for the correct culprit
    public GameObject accusationResultPanel;
    public TMP_Text accusationResultText;

    public void AccuseSuspect(Suspect chosenSuspect)
    {
        if (accusationResultPanel != null && accusationResultText != null && chosenSuspect != null && correctCulprit != null)
        {
            accusationResultPanel.SetActive(true);

            if (chosenSuspect.suspectName.ToLower() == correctCulprit.suspectName.ToLower())
            {
                AudioManager.Instance.PlayWinSound();
                UIManager.Instance.yesButton.SetActive(false);
                UIManager.Instance.noButton.SetActive(false);
                accusationResultPanel.SetActive(true);
                accusationResultText.text = "CORRECT! You've solved the mystery detective!";
            }
            else
            {
                AudioManager.Instance.PlayLoseSound();
                UIManager.Instance.yesButton.SetActive(true);
                UIManager.Instance.noButton.SetActive(true);
                accusationResultPanel.SetActive(true);
                accusationResultText.text = "Haha! Better luck next time detective!\n Try again?";
            }
        }
    }
}
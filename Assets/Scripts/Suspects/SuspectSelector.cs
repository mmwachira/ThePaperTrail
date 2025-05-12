using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SuspectSelector : MonoBehaviour
{
    public Suspect correctCulprit; // Scriptable Object for the correct culprit
    public GameObject accusationResultPanel;
    public TMP_Text accusationResultText;

    // ... (Awake function remains the same)

    public void AccuseSuspect(Suspect chosenSuspect)
    {
        if (accusationResultPanel != null && accusationResultText != null && chosenSuspect != null && correctCulprit != null)
        {
            accusationResultPanel.SetActive(true);

            if (chosenSuspect.suspectName.ToLower() == correctCulprit.suspectName.ToLower())
            {
                accusationResultText.text = "CORRECT! You've solved the mystery!";
            }
            else
            {
                accusationResultText.text = $"INCORRECT! The culprit was the {correctCulprit.suspectName}. Better luck next time!";
            }
        }
        // ... (Error handling)
    }
}
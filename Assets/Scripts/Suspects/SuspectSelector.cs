using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SuspectSelector : MonoBehaviour
{
    public static SuspectSelector Instance;
    public Suspect correctCulprit; // Scriptable Object for the correct culprit
    public GameObject accusationResultPanel;
    public TMP_Text accusationResultText;

    [SerializeField] private Suspect lastAccusedSuspect;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void AccuseSuspect(Suspect chosenSuspect)
    {
        lastAccusedSuspect = chosenSuspect;
        Debug.Log("Accused Suspect: " + (lastAccusedSuspect != null ? lastAccusedSuspect.suspectName : "null"));
        if (accusationResultPanel != null && accusationResultText != null && chosenSuspect != null && correctCulprit != null)
        {
            accusationResultPanel.SetActive(true);

            if (chosenSuspect.suspectName.ToLower() == correctCulprit.suspectName.ToLower())
            {
                AudioManager.Instance.PlayWinSound();
                UIManager.Instance.yesButton.SetActive(true);
                UIManager.Instance.noButton.SetActive(true);
                UIManager.Instance.WarningPanel.SetActive(false);
                UIManager.Instance.confirmButton.SetActive(false);
                UIManager.Instance.cancelButton.SetActive(false);
                accusationResultPanel.SetActive(true);
                accusationResultText.text = "Noooooo! One more day and I would have gotten away with it!\n But you are a good detective, I must admit.\n I will be back for revenge!";
            }
            else
            {
                AudioManager.Instance.PlayLoseSound();
                UIManager.Instance.yesButton.SetActive(true);
                UIManager.Instance.noButton.SetActive(true);
                UIManager.Instance.WarningPanel.SetActive(false);
                UIManager.Instance.confirmButton.SetActive(false);
                UIManager.Instance.cancelButton.SetActive(false);
                accusationResultPanel.SetActive(true);
                accusationResultText.text = "Haha! Better luck next time detective!\n Who knows what gallery I will rob next...";
            }
        }
    }

    public Suspect GetLastAccusedSuspect()
    {
        return lastAccusedSuspect;
    }
}
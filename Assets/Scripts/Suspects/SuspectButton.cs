using UnityEngine;
using UnityEngine.UI;

public class SuspectButton : MonoBehaviour
{
    public Suspect suspectDataSO; // Reference to the Suspect Scriptable Object
    [SerializeField] private SuspectSelector suspectSelector;
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(ShowConfirmation);
        }
        else
        {
            Debug.LogError("Button component not found on this GameObject!");
        }
    }

    void ShowConfirmation()
    {
        // Show the confirmation panel
        if (UIManager.Instance.WarningPanel != null)
        {
            UIManager.Instance.WarningPanel.SetActive(true);
            UIManager.Instance.warningText.text = "Are you sure you want to accuse " + suspectDataSO.suspectName + "?";
            UIManager.Instance.confirmButton.SetActive(true);
            UIManager.Instance.cancelButton.SetActive(true);
            UIManager.Instance.confirmButton.GetComponent<Button>().onClick.AddListener(OnConfirm);
            UIManager.Instance.cancelButton.GetComponent<Button>().onClick.AddListener(OnCancel);
        }
        else
        {
            Debug.LogError("WarningPanel not found!");
        }
    }

    void OnConfirm()
    {
        if (suspectSelector != null && suspectDataSO != null)
        {
            Suspect suspect = new Suspect { suspectName = suspectDataSO.suspectName };
            suspectSelector.AccuseSuspect(suspect);
        }
        else
        {
            Debug.LogError("SuspectSelector not found or SuspectSO not assigned!");
        }
    }

    void OnCancel()
    {
        // Hide the confirmation panel when canceling
        if (UIManager.Instance.WarningPanel != null)
        {
            UIManager.Instance.WarningPanel.SetActive(false);
        }
    }

}
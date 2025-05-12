using UnityEngine;
using UnityEngine.UI;

public class SuspectButton : MonoBehaviour
{
    public Suspect suspectDataSO; // Reference to the Suspect Scriptable Object
    [SerializeField] private SuspectSelector suspectSelector;
    private Button button;

    void Start()
    {
        //suspectSelector = FindAnyObjectByType<SuspectSelector>();
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogError("Button component not found on this GameObject!");
        }
    }

    void OnButtonClick()
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
}
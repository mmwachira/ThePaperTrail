using UnityEngine;
using UnityEngine.UI;

public class SuspectSummary : MonoBehaviour
{
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(ShowSummaryOfLastAccused);
        }
        else
        {
            Debug.LogError("Button component not found on this GameObject!");
        }
    }

    void ShowSummaryOfLastAccused()
    {
        if (UIManager.Instance != null && SuspectSelector.Instance != null)
        {
            Suspect lastSuspect = SuspectSelector.Instance.GetLastAccusedSuspect();
            if (lastSuspect != null)
            {
                UIManager.Instance.ShowSummary(lastSuspect);
            }
            else
            {
                Debug.LogError("No suspect has been accused yet!");
            }
        }
        else
        {
            Debug.LogError("UIManager or SuspectSelector Instance not found!");
        }
    }
}
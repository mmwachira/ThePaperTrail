using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StickyNote : MonoBehaviour
{
    public GameObject cluePopup; // The UI panel that shows the clue
    public TMP_Text clueText; // The Text component inside the popup
    [TextArea]
    public string clueMessage; // Clue text you want to show

    private void Start()
    {
        if (cluePopup != null)
            cluePopup.SetActive(false);
    }

    public void ShowClue()
    {
        if (cluePopup != null)
        {
            cluePopup.SetActive(true);
            clueText.text = clueMessage;
        }
    }

    public void HideClue()
    {
        if (cluePopup != null)
        {
            cluePopup.SetActive(false);
        }
    }
}

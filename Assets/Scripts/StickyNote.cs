using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StickyNote : MonoBehaviour
{
    public GameObject cluePopup; // The UI panel that shows the clue
    public TMP_Text clueText; // The Text component inside the popup
    [TextArea]
    public string clueMessage; // Clue text you want to show
    public bool clueOpened = false; // To track if the clue is opened

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
            clueOpened = true; // Set to true when the clue is opened
        }
    }

    public void HideClue()
    {
        Debug.Log("Hiding clue popup");
        if (cluePopup != null)
        {
            cluePopup.SetActive(false);
        }
    }
}

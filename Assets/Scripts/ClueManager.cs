using Unity.VisualScripting;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
    [Header("Assign the sticky note GameObject to show")]
    public GameObject stickyNoteClue;

    private bool clueRevealed = false;


    public void OnNewspaperClicked()
    {

        // Reveal the sticky note clue ONCE
        if (!clueRevealed && stickyNoteClue != null)
        {
            stickyNoteClue.SetActive(true);
            clueRevealed = true;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class NewspaperManager : MonoBehaviour
{

    [Header("Newspaper GameObjects")]
    public GameObject[] newspapers; // Drag and drop your 4 newspapers here

    [Header("UI Elements")]
    public GameObject suspectSelectionPanel; // Panel where player selects suspects
    public GameObject notepadPanel;          // Optional: your notepad panel

    private int currentPhase = 0; // 0 = first newspaper

    private bool articleOpened = false;

    private void Start()
    {
        ActivateOnlyCurrentNewspaper();
    }

    private void Update()
    {
        // Optional: open/close notepad with a key
        if (Input.GetKeyDown(KeyCode.N))
        {
            ToggleNotepad();
        }
        // if (articleOpened)
        // {
        //     UnlockNextNewspaper(); // Unlock next newspaper when article is opened
        //     articleOpened = false; // Reset the articleOpened state
        // }
    }

    public void OpenArticle()
    {
        if (!articleOpened)
        {
            articleOpened = true;

        }
    }

    public void ReadyForSuspectSelection()
    {
        suspectSelectionPanel.SetActive(true);
    }

    public void SelectSuspect()
    {
        suspectSelectionPanel.SetActive(false);
        articleOpened = false;

        currentPhase++;

        if (currentPhase >= newspapers.Length)
        {
            Debug.Log("All newspapers done! Show final screen.");
            // TODO: Show final conclusion screen
            return;
        }

        ActivateOnlyCurrentNewspaper();
    }

    private void ActivateOnlyCurrentNewspaper()
    {
        for (int i = 0; i < newspapers.Length; i++)
        {
            newspapers[i].SetActive(i == currentPhase);
        }
    }

    private void ActivateCurrentNewspaper()
    {
        newspapers[currentPhase].SetActive(true);
    }

    public void UnlockNextNewspaper()
    {
        if (currentPhase < newspapers.Length - 1)
        {
            currentPhase++;
            ActivateCurrentNewspaper();
            //ActivateOnlyCurrentNewspaper();
        }
    }

    private void ToggleNotepad()
    {
        if (notepadPanel != null)
        {
            notepadPanel.SetActive(!notepadPanel.activeSelf);
        }
    }
}

using Unity.VisualScripting;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
    //public GameObject cluePanel; // Assign in the inspector
    public GameObject[] Clues;

    //private bool clueRevealed = false;


    public void OnNewspaperClicked(int index)
    {

        // Show the clue when the newspaper is clicked
        ShowClue(index);
    }
    private void ShowClue(int index)
    {

        // Activate the clue GameObject
        // for (int i = 0; i < Clues.Length; i++)
        // {
        //     Clues[i].SetActive(i == index); // Activate the clicked clue
        // }
        Clues[index].SetActive(true);
    }
}

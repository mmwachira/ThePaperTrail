using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClueManager : MonoBehaviour
{
    public static ClueManager Instance;

    public List<string> foundClues = new List<string>();
    public TMP_Text[] clueTexts;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void AddClue(string clueText)
    {
        if (!foundClues.Contains(clueText))
        {
            foundClues.Add(clueText);
            UpdateInventoryUI();
        }
    }

    void UpdateInventoryUI()
    {
        for (int i = 0; i < clueTexts.Length; i++)
        {
            clueTexts[i].text = i < foundClues.Count ? foundClues[i] : "Clue " + (i + 1) + ": ___";
        }
    }
}

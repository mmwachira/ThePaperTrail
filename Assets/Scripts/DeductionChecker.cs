using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeductionChecker : MonoBehaviour
{
    public TMP_Dropdown clueDropdown1, clueDropdown2, clueDropdown3, clueDropdown4;

    private string[] correctAnswers = {
        "Suspect carrying something",
        "Bag colour - BLACK",
        "Game end time - 2:45",
        "Low visibility at some time"
    };

    public void CheckAnswers()
    {
        string[] selected = {
            clueDropdown1.options[clueDropdown1.value].text,
            clueDropdown2.options[clueDropdown2.value].text,
            clueDropdown3.options[clueDropdown3.value].text,
            clueDropdown4.options[clueDropdown4.value].text
        };

        int correctCount = 0;
        foreach (var clue in correctAnswers)
        {
            if (System.Array.Exists(selected, x => x == clue))
                correctCount++;
        }

        if (correctCount == 3)
        {
            UIManager.Instance.ShowWin();
        }
        else
        {
            UIManager.Instance.ShowHint("Hmm… maybe check the museum or sports article again.");
        }
    }
}

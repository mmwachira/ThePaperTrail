using UnityEngine;

public class ClueButton : MonoBehaviour
{
    public string clueText;

    public void OnClick()
    {
        ClueManager.Instance.AddClue(clueText);
        // Optional popup to explain more
        UIManager.Instance.ShowCluePopup(clueText);
    }
}

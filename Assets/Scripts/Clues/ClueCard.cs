using UnityEngine;

public class ClueCard : MonoBehaviour
{
    public Clue clueData;
    public RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public int GetID()
    {
        return clueData != null ? clueData.clueID : -1;
    }
}

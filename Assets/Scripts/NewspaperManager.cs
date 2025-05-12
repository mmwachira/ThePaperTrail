using UnityEngine;
using UnityEngine.UI;

public class NewspaperManager : MonoBehaviour
{

    [Header("Newspaper GameObjects")]
    public GameObject[] newspapers; // Drag and drop your 4 newspapers here

    private int currentPhase = 0; // 0 = first newspaper

    private bool articleOpened = false;

    private void Start()
    {
        ActivateOnlyCurrentNewspaper();
    }

    public void OpenArticle()
    {
        if (!articleOpened)
        {
            articleOpened = true;

        }
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
        }
    }
}

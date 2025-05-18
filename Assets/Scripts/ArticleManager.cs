using UnityEngine;
using UnityEngine.UI;

public class ArticleManager : MonoBehaviour
{
    public GameObject[] articles;
    public GameObject[] newsPapers;
    public GameObject articlePanel;
    private void Start()
    {
        ActivateOnlyUnlockedNewspaper();
    }

    private void ActivateOnlyUnlockedNewspaper()
    {
        for (int i = 0; i < articles.Length; i++)
        {
            newsPapers[i].SetActive(i == 0); // Hide all newspapers except the first one
        }
    }

    public void ShowArticle(int index)
    {

        GameManager.Instance.investigationBoard.SetActive(false); // Hide the investigation board
        articlePanel.SetActive(true); // Show the article panel
        articles[index].SetActive(true); // Show selected
        GameManager.Instance.openNewspaperAnimator.SetTrigger("Stop"); // Stop the newspaper animation

    }

    public void UnlockNextArticle(int index)
    {
        if (index >= 0 && index < articles.Length)
        {
            newsPapers[index].SetActive(true); // Show the newspaper at the given index
        }
        else
        {
            Debug.LogWarning("Invalid article index: " + index);
        }
    }

    public void CloseArticle(int index)
    {
        articlePanel.SetActive(false); // Hide the article panel
        articles[index].SetActive(false); // Hide selected article
        GameManager.Instance.investigationBoard.SetActive(true); // Show the investigation board again

    }

}

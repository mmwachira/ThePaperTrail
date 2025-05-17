using UnityEngine;
using UnityEngine.UI;

public class ArticleManager : MonoBehaviour
{
    public GameObject[] articles; // Assign in the inspector
    public GameObject articlePanel; // Assign in the inspector

    public void ShowArticle(int index)
    {

        GameManager.Instance.investigationBoard.SetActive(false); // Hide the investigation board
        articlePanel.SetActive(true); // Show the article panel
        articles[index].SetActive(true); // Show selected
        GameManager.Instance.openNewspaperAnimator.SetTrigger("Stop"); // Stop the newspaper animation
    }

    public void CloseArticle(int index)
    {
        articlePanel.SetActive(false); // Hide the article panel
        articles[index].SetActive(false); // Hide selected article
        GameManager.Instance.investigationBoard.SetActive(true); // Show the investigation board again

    }

}

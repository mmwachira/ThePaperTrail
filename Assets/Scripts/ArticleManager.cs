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
    }

    public void CloseArticle()
    {
        articlePanel.SetActive(false); // Hide the article panel
        GameManager.Instance.investigationBoard.SetActive(true); // Show the investigation board again

    }

}

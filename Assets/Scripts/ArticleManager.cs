using UnityEngine;
using UnityEngine.UI;

public class ArticleManager : MonoBehaviour
{
    public GameObject[] articles; // Assign in the inspector
    public GameObject enlargedArticleDisplay;
    public Image enlargedImageDisplay; // Image component inside EnlargedArticleDisplay

    public void ShowArticle(int index)
    {
        // Hide all first
        foreach (var article in articles)
            article.SetActive(false);

        // Show selected
        articles[index].SetActive(true);
    }

    public void EnlargeArticle(Sprite articleSprite)
    {
        enlargedImageDisplay.sprite = articleSprite;
        enlargedArticleDisplay.SetActive(true);
    }

    public void CloseEnlargedView()
    {
        enlargedArticleDisplay.SetActive(false);
    }
}

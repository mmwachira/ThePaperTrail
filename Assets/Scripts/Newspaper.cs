using UnityEngine;
using UnityEngine.UI;

public class Newspaper : MonoBehaviour
{
    public string newspaperName;
    public Text articleText;

    void Start()
    {
        DisplayArticle();
    }

    void DisplayArticle()
    {
        articleText.text = "Welcome to " + newspaperName + ". Here's the latest crime update!";
    }
}

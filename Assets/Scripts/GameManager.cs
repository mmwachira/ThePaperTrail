using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Animator frontPageAnimator;
    public GameObject frontPage;
    public GameObject newsPanel1;
    public GameObject deductionPanel;
    public GameObject startButton;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {

        frontPage.SetActive(true);

        StartCoroutine(ShowStartButton(2f)); // Show start button after 2 seconds
    }

    public void OpenDeductionPanel()
    {
        deductionPanel.SetActive(true);
    }


    public IEnumerator ShowStartButton(float delay)
    {
        yield return new WaitForSeconds(delay);
        startButton.SetActive(true);
    }

    public IEnumerator ShowNews(float delay)
    {
        yield return new WaitForSeconds(delay);
        newsPanel1.SetActive(true);
        frontPage.SetActive(false);
    }

    public void StartGame()
    {
        frontPageAnimator.SetTrigger("Minimize");
        startButton.SetActive(false);

        StartCoroutine(ShowNews(2f));


    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ClueManager : MonoBehaviour
{
    public ClueCard[] clueCards; // draggable clue objects
    public RectTransform[] targetZones; // invisible placeholder areas
    public int[] correctIDs;  // correct clue order
    public Color correctColor = Color.green; // color for correct clues
    public Color incorrectColor = Color.red; // color for incorrect clues
    public float highlightDuration = 0.2f; // duration for highlighting clues
    public bool allCorrect = false; // flag to check if all clues are in the correct position
    public GameObject culpritchoicePanel; // panel to choose the culprit

    public float snapDistanceThreshold = 50f; // distance threshold for snapping

    private ClueCard[] snappedClues; // Keep track of which clue is snapped to which target
    private Image[] targetZoneImages; // To access image components for color changes

    void Start()
    {
        snappedClues = new ClueCard[targetZones.Length];
        targetZoneImages = new Image[targetZones.Length];
        // Get the Image components from target zones
        for (int i = 0; i < targetZones.Length; i++)
        {
            targetZoneImages[i] = targetZones[i].GetComponent<Image>();
            if (targetZoneImages[i] == null)
            {
                Debug.LogWarning("No Image component found on target zone " + i);
            }
            else
            {
                targetZoneImages[i].color = Color.clear; // Initialize with no color
            }
        }
    }

    public void AttemptSnap(FreeDraggable draggable)
    {
        RectTransform draggableRect = draggable.GetRectTransform();
        ClueCard clueCard = draggable.GetClueCardComponent();
        float closestDistance = float.MaxValue;
        RectTransform closestTarget = null;
        int closestIndex = -1;

        for (int i = 0; i < targetZones.Length; i++)
        {

            float distance = Vector2.Distance(draggableRect.anchoredPosition, targetZones[i].anchoredPosition);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = targetZones[i];
                closestIndex = i;
            }
        }

        if (closestDistance < snapDistanceThreshold)
        {
            // Snap the clue to the target zone
            draggableRect.anchoredPosition = closestTarget.anchoredPosition;
            // Store the snapped clue
            snappedClues[closestIndex] = clueCard;


        }
        else
        {
            // Reset position if not close enough
            draggableRect.SetParent(null);
        }
    }


    public void CheckCluePositions()
    {
        allCorrect = true;

        for (int i = 0; i < targetZones.Length; i++)
        {
            if (snappedClues[i] == null || snappedClues[i].GetID() != correctIDs[i])
            {
                allCorrect = false;
                if (targetZoneImages[i] != null)
                {
                    StartCoroutine(HighlightColor(targetZoneImages[i], incorrectColor));
                }
            }
            else
            {
                // Optionally highlight the correct target zone briefly
                if (targetZoneImages[i] != null)
                {
                    StartCoroutine(HighlightColor(targetZoneImages[i], correctColor));
                }
            }
        }
        // Check if all clues are in the correct position

        if (allCorrect)
        {
            StartCoroutine(ShowFinalObjective()); // Show final message after 2 seconds

        }
        else
        {
            UIManager.Instance.ShowWarning("Incorrect order! Please try again.");

        }

    }

    private IEnumerator HighlightColor(Image imageToHighlight, Color highlight)
    {
        Color originalColor = imageToHighlight.color;
        imageToHighlight.color = highlight;
        yield return new WaitForSeconds(highlightDuration);
        imageToHighlight.color = originalColor;
    }

    private IEnumerator ShowFinalObjective()
    {
        AudioManager.Instance.PlayAccusationMusic();
        UIManager.Instance.ShowWarning("Correct order!");
        yield return new WaitForSeconds(UIManager.Instance.GetWarningDuration());
        culpritchoicePanel.SetActive(true); // Show the culprit choice panel
        UIManager.Instance.ShowObjective("Choose the culprit. You only have one chance!");
    }


    public void OnNewspaperClicked(int index)
    {
        if (index >= 0 && index < clueCards.Length)
        {
            clueCards[index].gameObject.SetActive(true);
        }
    }

}

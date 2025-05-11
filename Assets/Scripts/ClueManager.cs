using UnityEngine;

public class ClueManager : MonoBehaviour
{
    public ClueCard[] clueCards; // draggable clue objects
    public RectTransform[] targetZones; // invisible placeholder areas
    public int[] correctIDs;  // correct clue order
    public bool allCorrect = false; // flag to check if all clues are in the correct position

    public float snapDistanceThreshold = 50f; // distance threshold for snapping

    private ClueCard[] snappedClues; // Keep track of which clue is snapped to which target

    void Start()
    {
        snappedClues = new ClueCard[targetZones.Length];
    }

    public void AttemptSnap(FreeDraggable draggable)
    {
        Debug.Log("AttemptSnap called");
        RectTransform draggableRect = draggable.GetRectTransform();
        ClueCard clueCard = draggable.GetClueCardComponent();
        float closestDistance = float.MaxValue;
        RectTransform closestTarget = null;
        int closestIndex = -1;

        for (int i = 0; i < targetZones.Length; i++)
        {

            float distance = Vector2.Distance(draggableRect.anchoredPosition, targetZones[i].anchoredPosition);
            Debug.Log($"Distance to target {i}: {distance}");
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = targetZones[i];
                closestIndex = i;
            }
        }
        Debug.Log($"Closest distance: {closestDistance}, Threshold: {snapDistanceThreshold}");

        if (closestDistance < snapDistanceThreshold)
        {
            // Snap the clue to the target zone
            draggableRect.anchoredPosition = closestTarget.anchoredPosition;
            // Store the snapped clue
            snappedClues[closestIndex] = clueCard;
            Debug.Log($"Snapped to target {closestIndex}");

        }
        else
        {
            // Reset position if not close enough
            Debug.Log("No snap");
            draggableRect.SetParent(null);
        }
    }


    public void CheckCluePositions()
    {
        allCorrect = true;

        for (int i = 0; i < targetZones.Length; i++)
        {
            if (snappedClues[i] == null)
            {
                allCorrect = false;
                Debug.Log($"Clue at index {i} is not snapped.");
            }
            else
            {
                int snappedClueID = snappedClues[i].GetID(); // Get the integer ID directly
                if (snappedClueID != correctIDs[i])
                {
                    allCorrect = false;
                    Debug.Log($"Target {i}: Incorrect clue ID. Expected {correctIDs[i]}, got {snappedClueID}.");
                }
                else
                {
                    Debug.Log($"Target {i}: Correct clue ID {snappedClueID}.");
                }
            }

        }

        if (allCorrect)
        {
            Debug.Log("Correct order!");
            // Continue to next phase
        }
        else
        {
            Debug.Log("Incorrect order!");
        }
    }


    public void OnNewspaperClicked(int index)
    {
        if (index >= 0 && index < clueCards.Length)
        {
            clueCards[index].gameObject.SetActive(true);
        }
    }

}

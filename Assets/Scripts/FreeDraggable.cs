using UnityEngine;
using UnityEngine.EventSystems;

public class FreeDraggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    public ClueManager clueManager; // Reference to ClueManager
    private bool isDragging = false;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        if (!canvasGroup) canvasGroup = gameObject.AddComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        canvasGroup.blocksRaycasts = true;
        if (clueManager != null)
        {
            clueManager.AttemptSnap(this);
            //clueManager.CheckCluePositions();
        }
    }

    public bool IsDragging()
    {
        return isDragging;
    }

    public RectTransform GetRectTransform()
    {
        return rectTransform;
    }

    public ClueCard GetClueCardComponent()
    {
        return GetComponent<ClueCard>();
    }
}

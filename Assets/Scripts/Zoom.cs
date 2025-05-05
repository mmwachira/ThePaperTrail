using UnityEngine;
using UnityEngine.EventSystems;

public class UI_ZoomAndPan : MonoBehaviour, IScrollHandler, IDragHandler, IBeginDragHandler
{
    public float zoomSpeed = 0.2f;
    public float minScale = 0.5f;
    public float maxScale = 2.5f;

    private RectTransform content;
    private RectTransform viewport;
    private Canvas canvas;

    private Vector2 dragStartPos;

    void Start()
    {
        content = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        viewport = content.parent.GetComponent<RectTransform>();
    }

    public void OnScroll(PointerEventData eventData)
    {
        Vector2 localCursor;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(content, eventData.position, canvas.worldCamera, out localCursor);

        Vector2 pivot = new Vector2(
            (localCursor.x / content.rect.width) + 0.5f,
            (localCursor.y / content.rect.height) + 0.5f);

        content.pivot = pivot;

        Vector3 newScale = content.localScale + Vector3.one * eventData.scrollDelta.y * zoomSpeed;
        newScale = ClampScaleToViewport(newScale);

        content.localScale = newScale;

        ClampToBounds();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragStartPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 delta = eventData.position - dragStartPos;
        content.anchoredPosition += delta;
        dragStartPos = eventData.position;

        ClampToBounds();
    }

    Vector3 ClampScaleToViewport(Vector3 scale)
    {
        // Ensure content never gets smaller than viewport
        Vector2 contentSize = content.rect.size;
        Vector2 scaledSize = new Vector2(contentSize.x * scale.x, contentSize.y * scale.y);
        Vector2 viewSize = viewport.rect.size;

        float minX = viewSize.x / contentSize.x;
        float minY = viewSize.y / contentSize.y;

        float min = Mathf.Max(minX, minY, minScale);

        scale.x = Mathf.Clamp(scale.x, min, maxScale);
        scale.y = Mathf.Clamp(scale.y, min, maxScale);
        scale.z = 1f;

        return scale;
    }

    void ClampToBounds()
    {
        Vector2 viewSize = viewport.rect.size;
        Vector2 contentSize = content.rect.size;
        Vector2 scaledSize = new Vector2(contentSize.x * content.localScale.x, contentSize.y * content.localScale.y);

        Vector2 min = Vector2.zero;
        Vector2 max = scaledSize - viewSize;

        // If content is smaller than viewport, center it
        if (scaledSize.x <= viewSize.x)
            content.anchoredPosition = new Vector2(0, content.anchoredPosition.y);
        else
        {
            float x = Mathf.Clamp(content.anchoredPosition.x, -max.x * 0.5f, max.x * 0.5f);
            content.anchoredPosition = new Vector2(x, content.anchoredPosition.y);
        }

        if (scaledSize.y <= viewSize.y)
            content.anchoredPosition = new Vector2(content.anchoredPosition.x, 0);
        else
        {
            float y = Mathf.Clamp(content.anchoredPosition.y, -max.y * 0.5f, max.y * 0.5f);
            content.anchoredPosition = new Vector2(content.anchoredPosition.x, y);
        }
    }

}

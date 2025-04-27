using UnityEngine;

public class Zoom : MonoBehaviour
{
    public float zoomSpeed = 0.2f;
    public float minScale = 0.5f;
    public float maxScale = 2.5f;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (Mathf.Abs(scroll) > 0.01f)
        {
            Vector3 cursorWorldPosBeforeZoom = cam.ScreenToWorldPoint(Input.mousePosition);

            // Zoom logic
            Vector3 scale = transform.localScale;
            scale += Vector3.one * scroll * zoomSpeed;
            scale = ClampScale(scale);
            transform.localScale = scale;

            // Maintain position under cursor
            Vector3 cursorWorldPosAfterZoom = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 diff = cursorWorldPosBeforeZoom - cursorWorldPosAfterZoom;
            transform.position += diff;
        }
    }

    Vector3 ClampScale(Vector3 scale)
    {
        scale.x = Mathf.Clamp(scale.x, minScale, maxScale);
        scale.y = Mathf.Clamp(scale.y, minScale, maxScale);
        scale.z = 1f;
        return scale;
    }
}

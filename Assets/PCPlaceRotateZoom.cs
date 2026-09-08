using UnityEngine;
using UnityEngine.EventSystems;

public class PCPlaceRotateZoom : MonoBehaviour
{
    [Header("Prefab to place")]
    public GameObject prefab;

    [Header("Placement")]
    public LayerMask groundMask;
    public float spawnScale = 1f;

    [Header("Rotate/Zoom")]
    public float rotateSpeed = 0.2f;
    public float zoomSpeed = 2f;
    public float minScale = 0.2f;
    public float maxScale = 3f;

    private Camera cam;
    private GameObject spawned;

    private bool dragging;
    private Vector3 lastMouse;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        // Ignore UI clicks
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            return;

        // PLACE on left click
        if (Input.GetMouseButtonDown(0))
        {
            PlaceAtMouse();
        }

        // ROTATE with right mouse drag (or change to left drag if you want)
        if (spawned != null)
        {
            if (Input.GetMouseButtonDown(1))
            {
                dragging = true;
                lastMouse = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(1)) dragging = false;

            if (dragging)
            {
                Vector3 delta = Input.mousePosition - lastMouse;
                lastMouse = Input.mousePosition;

                float rotY = delta.x * rotateSpeed;
                spawned.transform.Rotate(0f, -rotY, 0f, Space.World);
            }

            // ZOOM using mouse scroll
            float scroll = Input.mouseScrollDelta.y;
            if (Mathf.Abs(scroll) > 0.001f)
            {
                float newScale = spawned.transform.localScale.x + scroll * zoomSpeed * Time.deltaTime;
                newScale = Mathf.Clamp(newScale, minScale, maxScale);
                spawned.transform.localScale = Vector3.one * newScale;
            }
        }
    }

    void PlaceAtMouse()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 1000f, groundMask))
        {
            if (spawned == null)
            {
                spawned = Instantiate(prefab, hit.point, Quaternion.identity);
                spawned.transform.localScale = Vector3.one * spawnScale;
            }
            else
            {
                spawned.transform.position = hit.point;
            }
        }
    }
}
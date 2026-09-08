using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Utilities;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

public class ModelTapInfo : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject[] panels;

    [Header("Pointers (Cylinders)")]
    public GameObject[] cylinderPointers;

    private Camera mainCamera;
    private bool isActive = false;

    void OnEnable()
    {
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.TouchSimulation.Enable();
    }

    void OnDisable()
    {
        EnhancedTouch.EnhancedTouchSupport.Disable();
        EnhancedTouch.TouchSimulation.Disable();
    }

    void Start()
    {
        mainCamera = Camera.main;
        HideAll();
    }

    void Update()
    {
        var touches = EnhancedTouch.Touch.activeTouches;

        // Only respond to 1-finger taps
        if (touches.Count == 1 && touches[0].phase == UnityEngine.InputSystem.TouchPhase.Began)
        {
            var t = touches[0];

            // If tap is on UI (button/panel), ignore world tap
            if (IsTouchOnUI(t.screenPosition))
                return;

            HandleWorldTap(t.screenPosition);
        }

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            if (IsMouseOnUI())
                return;

            HandleWorldTap(Input.mousePosition);
        }
#endif
    }

    private bool IsTouchOnUI(Vector2 screenPosition)
    {
        if (EventSystem.current == null)
            return false;

        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = screenPosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        return results.Count > 0;
    }

    private bool IsMouseOnUI()
    {
        if (EventSystem.current == null)
            return false;

        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        return results.Count > 0;
    }

    void HandleWorldTap(Vector2 screenPosition)
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        if (mainCamera == null)
            return;

        Ray ray = mainCamera.ScreenPointToRay(screenPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == transform || hit.transform.IsChildOf(transform))
                ToggleInfo();
            else
                HideAll();
        }
        else
        {
            HideAll();
        }
    }

    void ToggleInfo()
    {
        isActive = !isActive;

        foreach (GameObject panel in panels)
        {
            if (panel != null)
                panel.SetActive(isActive);
        }

        foreach (GameObject cylinder in cylinderPointers)
        {
            if (cylinder != null)
                cylinder.SetActive(isActive);
        }
    }

    public void HideAll()
    {
        isActive = false;

        foreach (GameObject panel in panels)
        {
            if (panel != null)
                panel.SetActive(false);
        }

        foreach (GameObject cylinder in cylinderPointers)
        {
            if (cylinder != null)
                cylinder.SetActive(false);
        }
    }
}
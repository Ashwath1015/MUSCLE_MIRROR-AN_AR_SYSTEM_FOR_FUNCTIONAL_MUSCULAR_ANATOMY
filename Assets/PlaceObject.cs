using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem.Utilities;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

[RequireComponent(typeof(ARRaycastManager), typeof(ARPlaneManager))]
public class PlaceObject : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    [Header("Spawn Scale")]
    [SerializeField] private float startScale = 0.2f;
    [SerializeField] private float minScale = 0.05f;
    [SerializeField] private float maxScale = 1.0f;

    [Header("Placement Offset")]
    [SerializeField] private float yOffset = 0.1f;   // adjust in Inspector

    [Header("Rotation (1 finger drag)")]
    [SerializeField] private float rotationSpeed = 0.15f;

    private ARRaycastManager arRaycastManager;
    private ARPlaneManager arPlaneManager;
    private static readonly List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private GameObject spawnedObject;
    private bool objectPlaced = false;

    // 2 finger scale
    private float initialDistance;
    private Vector3 initialScale;

    // 1 finger rotate
    private Vector2 lastOneFingerPos;
    private bool oneFingerRotating = false;

    private void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        arPlaneManager = GetComponent<ARPlaneManager>();
    }

    private void OnEnable()
    {
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.TouchSimulation.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouch.EnhancedTouchSupport.Disable();
        EnhancedTouch.TouchSimulation.Disable();
    }

    private void Update()
    {
        var touches = EnhancedTouch.Touch.activeTouches;

        // Ignore UI touches
        if (IsTouchingUI(touches))
            return;

        // ---------------- PLACE OBJECT (ONE TIME ONLY) ----------------
        if (!objectPlaced &&
            touches.Count == 1 &&
            touches[0].phase == UnityEngine.InputSystem.TouchPhase.Began)
        {
            if (arRaycastManager.Raycast(
                touches[0].screenPosition,
                hits,
                TrackableType.PlaneWithinPolygon))
            {
                Pose pose = hits[0].pose;

                // Apply Y offset
                Vector3 spawnPosition = pose.position + new Vector3(0f, yOffset, 0f);

                spawnedObject = Instantiate(prefab, spawnPosition, pose.rotation);
                spawnedObject.transform.localScale = Vector3.one * startScale;

                objectPlaced = true;
                DisablePlaneDetection();
            }
        }

        if (spawnedObject == null)
            return;

        // ---------------- 1 FINGER ROTATION ----------------
        if (touches.Count == 1)
        {
            var t = touches[0];

            if (t.phase == UnityEngine.InputSystem.TouchPhase.Began)
            {
                lastOneFingerPos = t.screenPosition;
                oneFingerRotating = true;
            }
            else if (oneFingerRotating &&
                     (t.phase == UnityEngine.InputSystem.TouchPhase.Moved ||
                      t.phase == UnityEngine.InputSystem.TouchPhase.Stationary))
            {
                Vector2 delta = t.screenPosition - lastOneFingerPos;
                lastOneFingerPos = t.screenPosition;

                float rotY = delta.x * rotationSpeed;
                spawnedObject.transform.Rotate(0f, -rotY, 0f, Space.World);
            }
            else if (t.phase == UnityEngine.InputSystem.TouchPhase.Ended ||
                     t.phase == UnityEngine.InputSystem.TouchPhase.Canceled)
            {
                oneFingerRotating = false;
            }
        }

        // ---------------- 2 FINGER SCALE ----------------
        if (touches.Count == 2)
        {
            var t1 = touches[0];
            var t2 = touches[1];

            if (t1.phase == UnityEngine.InputSystem.TouchPhase.Began ||
                t2.phase == UnityEngine.InputSystem.TouchPhase.Began)
            {
                initialDistance = Vector2.Distance(
                    t1.screenPosition,
                    t2.screenPosition
                );

                initialScale = spawnedObject.transform.localScale;
                return;
            }

            bool t1Stable = (t1.phase == UnityEngine.InputSystem.TouchPhase.Moved ||
                             t1.phase == UnityEngine.InputSystem.TouchPhase.Stationary);

            bool t2Stable = (t2.phase == UnityEngine.InputSystem.TouchPhase.Moved ||
                             t2.phase == UnityEngine.InputSystem.TouchPhase.Stationary);

            if (!t1Stable || !t2Stable)
                return;

            if (initialDistance < 0.001f)
                return;

            float currentDistance = Vector2.Distance(
                t1.screenPosition,
                t2.screenPosition
            );

            float scaleFactor = currentDistance / initialDistance;
            Vector3 targetScale = initialScale * scaleFactor;

            float s = Mathf.Clamp(targetScale.x, minScale, maxScale);
            spawnedObject.transform.localScale = new Vector3(s, s, s);
        }
    }

    private bool IsTouchingUI(ReadOnlyArray<EnhancedTouch.Touch> touches)
    {
        if (EventSystem.current == null)
            return false;

        // Mobile
        if (touches.Count > 0)
        {
            int fingerId = touches[0].touchId;
            if (EventSystem.current.IsPointerOverGameObject(fingerId))
                return true;
        }

        // Editor
        if (EventSystem.current.IsPointerOverGameObject())
            return true;

        return false;
    }

    private void DisablePlaneDetection()
    {
        arPlaneManager.enabled = false;

        foreach (var plane in arPlaneManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }
    }
}
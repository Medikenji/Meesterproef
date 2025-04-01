using UnityEngine;
using UnityEngine.InputSystem;

public class SimmacCamera : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private GameObject _followTarget;
    [SerializeField]
    private Vector2 snapPosition;
    [SerializeField]
    private int stoicSize = 20;
    [SerializeField]
    private int minSize = 3;
    [SerializeField]
    private int scrollSpeed = 1;
    private InputAction _scroll;

    void Start()
    {
        SetupInputActions();
    }

    void Update()
    {
        UpdateCameraZoom();
        UpdateCameraPosition();
        ClampCameraSize();
        FixCameraZPosition();
    }

    private void SetupInputActions()
    {
        _scroll = InputSystem.actions.FindAction("Camera");
    }

    private void UpdateCameraZoom()
    {
        float scrollValue = _scroll.ReadValue<float>();
        _camera.orthographicSize += scrollValue * scrollSpeed;
    }

    private void UpdateCameraPosition()
    {
        _camera.transform.position = _followTarget.transform.position;

        // If camera is at max zoom out level, snap to overview position
        if (_camera.orthographicSize > stoicSize)
        {
            _camera.transform.position = snapPosition;
        }
    }

    private void ClampCameraSize()
    {
        if (_camera.orthographicSize > stoicSize)
        {
            _camera.orthographicSize = stoicSize + 1;
        }

        if (_camera.orthographicSize < minSize)
        {
            _camera.orthographicSize = minSize;
        }
    }

    private void FixCameraZPosition()
    {
        // Ensure the camera stays at the correct depth
        Vector3 newPosition = _camera.transform.position;
        newPosition.z = -50;
        _camera.transform.position = newPosition;
    }
}

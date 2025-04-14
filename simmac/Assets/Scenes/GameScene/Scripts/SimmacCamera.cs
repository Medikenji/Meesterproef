using UnityEngine;
using UnityEngine.InputSystem;

public class SimmacCamera : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _followTarget;
    [SerializeField] private Vector2 _snapPosition;
    [SerializeField] private int _staticSize = 20;
    [SerializeField] private int _minSize = 3;
    [SerializeField] private int _scrollSpeed = 1;
    private InputAction _scroll;
    public bool isInMinigame = false;

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
        _camera.orthographicSize += scrollValue * _scrollSpeed;
    }

    private void UpdateCameraPosition()
    {
        _camera.transform.position = _followTarget.transform.position;

        // If camera is at max zoom out level, snap to overview position
        if (_camera.orthographicSize > _staticSize)
        {
            _camera.transform.position = _snapPosition;
        }
    }

    private void ClampCameraSize()
    {
        if (_camera.orthographicSize > _staticSize)
        {
            _camera.orthographicSize = _staticSize + 1;
        }

        if (_camera.orthographicSize < _minSize)
        {
            _camera.orthographicSize = _minSize;
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

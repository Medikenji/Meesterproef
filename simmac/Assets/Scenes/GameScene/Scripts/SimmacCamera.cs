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
        _scroll = InputSystem.actions.FindAction("Camera");
    }

    // Update is called once per frame
    void Update()
    {
        _camera.orthographicSize += _scroll.ReadValue<float>() * scrollSpeed;
        _camera.transform.position = _followTarget.transform.position;
        if (_camera.orthographicSize > stoicSize)
        {
            _camera.orthographicSize = stoicSize + 1;
            _camera.transform.position = snapPosition;
        }
        if (_camera.orthographicSize < minSize)
        {
            _camera.orthographicSize = minSize;
        }

        // Otherwise the player fucks up the position
        Vector3 newPosition = _camera.transform.position;
        newPosition.z = -50;
        _camera.transform.position = newPosition;
    }
}

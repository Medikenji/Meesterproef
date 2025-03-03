using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _velocity;

    [SerializeField] private float _speed;
    private InputAction _move;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _move = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        HandleInput();
        _rb.linearVelocity = _velocity;
    }

    void HandleInput()
    {
        Vector2 MoveValue = _move.ReadValue<Vector2>();
        MoveValue *= _speed;
        MoveValue = Vector2.ClampMagnitude(MoveValue, _speed);
        Debug.Log(MoveValue);
        _velocity = MoveValue;
    }
}



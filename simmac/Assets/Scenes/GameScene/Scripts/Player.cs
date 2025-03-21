using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private float _setSpeed = 8;
    private Rigidbody2D _rb;
    private Animator _animator;
    private Vector2 _velocity;
    private InputAction _move;
    private float _speed;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _move = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        HandleInput();
        _speed = _setSpeed;
        _rb.linearVelocity = _velocity;
    }

    void HandleInput()
    {
        Vector2 MoveValue = _move.ReadValue<Vector2>();

        if (MoveValue != Vector2.zero)
        {
            _animator.SetFloat("LastInputX", MoveValue.x);
            _animator.SetFloat("LastInputY", MoveValue.y);
        }

        MoveValue *= _speed;
        MoveValue = Vector2.ClampMagnitude(MoveValue, _speed);
        _velocity = MoveValue;
    }
}

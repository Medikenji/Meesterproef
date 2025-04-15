using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float _setSpeed = 8;
    private Rigidbody2D _rb;
    private Animator _animator;
    private Vector2 _velocity;
    private InputAction _move;
    private float _speed;

    void Start()
    {
        InitializeComponents();
        SetupInputActions();
    }

    void Update()
    {
        if (GameManager.instance.passTime)
        {
            HandleInput();
            UpdateMovementSpeed();
            ApplyVelocity();
        }
    }

    private void InitializeComponents()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void SetupInputActions()
    {
        _move = InputSystem.actions.FindAction("Move");
    }

    private void UpdateMovementSpeed()
    {
        _speed = _setSpeed;
    }

    private void ApplyVelocity()
    {
        _rb.linearVelocity = _velocity;
    }

    void HandleInput()
    {
        Vector2 moveValue = _move.ReadValue<Vector2>();

        UpdateAnimationParameters(moveValue);
        CalculateVelocity(moveValue);
    }

    private void UpdateAnimationParameters(Vector2 moveValue)
    {
        if (moveValue != Vector2.zero)
        {
            _animator.SetFloat("LastInputX", moveValue.x);
            _animator.SetFloat("LastInputY", moveValue.y);
        }
    }

    private void CalculateVelocity(Vector2 moveValue)
    {
        moveValue *= _speed;
        moveValue = Vector2.ClampMagnitude(moveValue, _speed);
        _velocity = moveValue;
    }
}

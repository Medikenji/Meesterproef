using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bag : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    public float speed;
    private InputAction _move;

    void Start()
    {
        transform.localScale *= Random.Range(1, 3); // small, medium, or large size bag
        _move = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        Vector2 moveValue = _move.ReadValue<Vector2>();
        Vector2 velocity = new(moveValue.x * speed, 0);
        _rb.linearVelocity = velocity;
    }
}

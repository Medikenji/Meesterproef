using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bag : MonoBehaviour
{
    [SerializeField]
    private Collider2D trigger;
    [SerializeField]
    private Rigidbody2D rb;
    public float speed;
    public int friesInBag;
    private InputAction _move;

    void Start()
    {
        _move = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        OnTriggerEnter2D(trigger);
        HandleInput();
    }

    void HandleInput()
    {
        Vector2 moveValue = _move.ReadValue<Vector2>();
        Vector2 velocity = new(moveValue.x * speed, 0);
        rb.linearVelocity = velocity;
    }

    private HashSet<Collider2D> triggeredColliders = new HashSet<Collider2D>();

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggeredColliders.Contains(collision))
        {
            triggeredColliders.Add(collision);
            print(++friesInBag);
        }
    }
}

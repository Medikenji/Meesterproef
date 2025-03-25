using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bag : MonoBehaviour
{
    public List<Rigidbody2D> rigidbodies;
    public List<GameObject> sprites;
    public float speed;
    public int friesInBag;
    private InputAction _move;

    void Start()
    {
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

        // Botched ass code to make sure the rigidbodies actually stay inside the
        // bag instead of clipping through I swear I tried so many alternative
        // routes but this is the only solution that worked reliably

        foreach (Rigidbody2D rb in rigidbodies)
        {
            rb.MovePosition(rb.position + velocity * Time.deltaTime);
        }

        foreach (GameObject sprite in sprites)
        {
            sprite.transform.position = sprite.transform.position + (Vector3)velocity * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        print(++friesInBag);
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class BurgerIngredient : MonoBehaviour
{
    public bool playerControlled;
    public float speed;
    private InputAction _move;

    void Start()
    {
        _move = InputSystem.actions.FindAction("Move");

        int randOffset = Random.Range(-6, 6);
        transform.position = new Vector3(8842 + randOffset, transform.position.y, transform.position.z);
    }

    void Update()
    {
        if (!playerControlled) { return ;}

        HandleInput();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        playerControlled = true;
    }

    void HandleInput()
    {
        Vector2 MoveValue = _move.ReadValue<Vector2>();
        float move = MoveValue.x * speed;
        transform.position += new Vector3(move, 0, 0);
    }
}

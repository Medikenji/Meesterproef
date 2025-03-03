using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _velocity;
    private Collider2D _torsoCol;
    private GameObject _torso;
    private Collider2D _legsCol;
    private GameObject _legs;
    [SerializeField] private float _speed;
    private InputAction _move;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _torso = GameObject.Find("Torso");
        _legs = GameObject.Find("Legs");
        _torsoCol = _torso.GetComponent<CapsuleCollider2D>();
        _legsCol = _legs.GetComponent<CapsuleCollider2D>();
        _move = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        HandleInput();
        HandleLegRotation();
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

    void HandleLegRotation()
    {
        if (_velocity != Vector2.zero)
        {
            float angle = Mathf.Atan2(_velocity.x, _velocity.y) * Mathf.Rad2Deg;
            _legs.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
        }
    }
}



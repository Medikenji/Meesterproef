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
    [SerializeField] private float _setSpeed;
    private float _speed;
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
        CheckForSlow();
        HandleInput();
        HandleLegRotation();
        HandleTorsoRotation();
        _speed = _setSpeed;
        _rb.linearVelocity = _velocity;
    }

    void HandleInput()
    {
        Vector2 MoveValue = _move.ReadValue<Vector2>();
        MoveValue *= _speed;
        MoveValue = Vector2.ClampMagnitude(MoveValue, _speed);
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

    void HandleTorsoRotation()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - _torso.transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        _torso.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
    }

    void CheckForSlow()
    {
        OnTriggerStay2D(_torsoCol);
        OnTriggerStay2D(_legsCol);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col == _torsoCol || col == _legsCol)
        {
            return;
        }
        _speed *= 0.8f;
    }
}



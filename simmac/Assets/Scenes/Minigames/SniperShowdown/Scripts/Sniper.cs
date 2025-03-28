using UnityEngine;
using UnityEngine.InputSystem;

public class Sniper : MonoBehaviour
{
    // public fields
    public Vector3 hitpoint;
    public float distanceCal = 0;
    public float windCal = 0;
    public int ammoAmount;

    // serialized private fields
    [SerializeField]
    private Sniper _scope;
    [SerializeField]
    private Target _target;
    [SerializeField]
    private GameObject _projectile;

    // private fields
    private float _reloadTimer = 0;
    private float _swayStrength;
    private Vector3 _sway = Vector3.zero;
    private InputAction _calibrateDistanceUp;
    private InputAction _calibrateDistanceDown;
    private InputAction _calibrateWindRight;
    private InputAction _calibrateWindLeft;
    private InputAction _move;
    private InputAction _shoot;

    // const values
    private const int AmmoAmount = 4;
    private const float SwayStart = 1;
    private const float ReloadTime = 3.0f;
    private const float MaxSwayStrength = 3.0f;
    private const float SwayIncreaseFactor = 0.05f;
    private const float MaxDistanceCal = 30.0f;
    private const float MaxWindCal = 20.0f;
    private const float MinPosition = -17.0f;
    private const float MaxPosition = 17.0f;
    private const float MinRecoil = 1.5f;
    private const float MaxRecoil = 3.5f;

    void Start()
    {
        SetInputs();
        ammoAmount = AmmoAmount;
        _swayStrength = SwayStart;
    }

    void Update()
    {
        Debug.DrawLine(_scope.transform.position, hitpoint);
        HandleMovement();
        HandleSway();
        HandleHitpoint();
        Shoot();
        _scope.transform.position += _sway;
    }

    void HandleMovement()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Vector2 moveInput = _move.ReadValue<Vector2>();
        Vector3 newPosition = _scope.transform.position + new Vector3(moveInput.x, moveInput.y, 0) * Time.deltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, MinPosition, MaxPosition);
        newPosition.y = Mathf.Clamp(newPosition.y, MinPosition, MaxPosition);
        _scope.transform.position = newPosition;
    }

    void HandleSway()
    {
        if (_swayStrength < MaxSwayStrength)
        {
            _swayStrength += _swayStrength * SwayIncreaseFactor * Time.deltaTime;
        }
        _sway = new Vector3(Random.Range(-_swayStrength, _swayStrength), Random.Range(-_swayStrength, _swayStrength), 0) * Time.deltaTime;
    }

    void HandleHitpoint()
    {
        if (_calibrateDistanceUp.triggered)
        {
            distanceCal += Random.Range(0.5f, 1.0f);
        }
        if (_calibrateDistanceDown.triggered)
        {
            distanceCal -= Random.Range(0.5f, 1.0f);
        }
        if (_calibrateWindRight.triggered)
        {
            windCal += Random.Range(0.5f, 1.0f);
        }
        if (_calibrateWindLeft.triggered)
        {
            windCal -= Random.Range(0.5f, 1.0f);
        }
        distanceCal = Mathf.Clamp(distanceCal, -MaxDistanceCal, MaxDistanceCal);
        windCal = Mathf.Clamp(windCal, -MaxWindCal, MaxWindCal);
        hitpoint = _scope.transform.position + new Vector3(_target.windStrength - windCal, -_target.distance + distanceCal, 0);
    }

    void SetInputs()
    {
        _calibrateDistanceUp = InputSystem.actions.FindAction("CalibrateUp");
        _calibrateDistanceDown = InputSystem.actions.FindAction("CalibrateDown");
        _calibrateWindRight = InputSystem.actions.FindAction("CalibrateRight");
        _calibrateWindLeft = InputSystem.actions.FindAction("CalibrateLeft");
        _move = InputSystem.actions.FindAction("MoveScope");
        _shoot = InputSystem.actions.FindAction("Shoot");
    }

    void Shoot()
    {
        _reloadTimer -= Time.deltaTime;
        if (_shoot.triggered && _reloadTimer < 0 && ammoAmount > 0)
        {
            ammoAmount--;
            _reloadTimer = ReloadTime;
            Instantiate(_projectile, hitpoint, Quaternion.identity);
            _swayStrength = SwayStart;
            ApplyRecoil();
        }
    }

    void ApplyRecoil()
    {
        float recoil = Random.Range(MinRecoil, MaxRecoil);
        _scope.transform.position += new Vector3(recoil, recoil, 0);
    }

    public bool shot()
    {
        return _shoot.triggered;
    }
}

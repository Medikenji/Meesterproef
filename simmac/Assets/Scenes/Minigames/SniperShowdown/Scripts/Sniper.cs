using UnityEngine;
using UnityEngine.InputSystem;

public class Sniper : MonoBehaviour
{
    public Vector3 hitpoint;
    public float distanceCal = 0;
    public float windCal = 0;
    public int ammoAmount;

    [SerializeField] private Sniper _scope;
    [SerializeField] private Target _target;
    [SerializeField] private GameObject _projectile;

    private float _reloadTimer = 0;
    private float _swayStrength;
    private Vector3 _sway = Vector3.zero;
    private InputAction _calibrateDistanceUp;
    private InputAction _calibrateDistanceDown;
    private InputAction _calibrateWindRight;
    private InputAction _calibrateWindLeft;
    private InputAction _move;
    private InputAction _shoot;

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
        InitializeSniper();
    }

    void Update()
    {
        DrawDebugLine();
        HandleMovement();
        HandleSway();
        HandleHitpoint();
        HandleShooting();
        ApplySway();
    }

    private void InitializeSniper()
    {
        SetInputs();
        InitializeAmmo();
        InitializeSway();
    }

    private void InitializeAmmo()
    {
        ammoAmount = AmmoAmount;
    }

    private void InitializeSway()
    {
        _swayStrength = SwayStart;
    }

    private void DrawDebugLine()
    {
        Debug.DrawLine(_scope.transform.position, hitpoint);
    }

    private void ApplySway()
    {
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
        HandleCalibration();
        CalculateHitpoint();
    }

    private void HandleCalibration()
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

        ClampCalibrationValues();
    }

    private void ClampCalibrationValues()
    {
        distanceCal = Mathf.Clamp(distanceCal, -MaxDistanceCal, MaxDistanceCal);
        windCal = Mathf.Clamp(windCal, -MaxWindCal, MaxWindCal);
    }

    private void CalculateHitpoint()
    {
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

    private void HandleShooting()
    {
        UpdateReloadTimer();
        TryToShoot();
    }

    private void UpdateReloadTimer()
    {
        _reloadTimer -= Time.deltaTime;
    }

    private void TryToShoot()
    {
        if (_shoot.triggered && _reloadTimer < 0 && ammoAmount > 0)
        {
            FireShot();
        }
    }

    private void FireShot()
    {
        ammoAmount--;
        _reloadTimer = ReloadTime;
        Instantiate(_projectile, hitpoint, Quaternion.identity);
        _swayStrength = SwayStart;
        ApplyRecoil();
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

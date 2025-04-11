using UnityEngine;
using UnityEngine.InputSystem;

public class SniperShowdown : MonoBehaviour
{
    public Vector3 hitpoint;
    public float distanceCal = 0;
    public float windCal = 0;
    public int ammoAmount;

    [SerializeField] private SniperShowdown _scope;
    [SerializeField] private Target _target;
    [SerializeField] private GameObject _projectile;

    private int _score;
    private float _reloadTimer = 0;
    private float _swayStrength;
    private Vector3 _sway = Vector3.zero;
    private InputAction _calibrateDistanceUp;
    private InputAction _calibrateDistanceDown;
    private InputAction _calibrateWindRight;
    private InputAction _calibrateWindLeft;
    private InputAction _move;
    private InputAction _shoot;

    private const int AMMO_AMOUNT = 4;
    private const float SWAY_START = 1;
    private const float RELOAD_TIME = 3.0f;
    private const float MAX_SWAY_STRENGTH = 3.0f;
    private const float SWAY_INCREASE_FACTOR = 0.05f;
    private const float MAX_DISTANCE_CAL = 30.0f;
    private const float MAX_WIND_CAL = 20.0f;

    // D: Could've just made plain floats and used Clampf() to handle min/max values
    private const float MIN_POSITION = -17.0f;
    private const float MAX_POSITION = 17.0f;
    private const float MIN_RECOIL = 1.5f;
    private const float MAX_RECOIL = 3.5f;

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
        ammoAmount = AMMO_AMOUNT;
    }

    private void InitializeSway()
    {
        _swayStrength = SWAY_START;
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
        newPosition.x = Mathf.Clamp(newPosition.x, MIN_POSITION, MAX_POSITION);
        newPosition.y = Mathf.Clamp(newPosition.y, MIN_POSITION, MAX_POSITION);
        _scope.transform.position = newPosition;
    }

    void HandleSway()
    {
        if (_swayStrength < MAX_SWAY_STRENGTH)
        {
            _swayStrength += _swayStrength * SWAY_INCREASE_FACTOR * Time.deltaTime;
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
        distanceCal = Mathf.Clamp(distanceCal, -MAX_DISTANCE_CAL, MAX_DISTANCE_CAL);
        windCal = Mathf.Clamp(windCal, -MAX_WIND_CAL, MAX_WIND_CAL);
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
        _reloadTimer = RELOAD_TIME;
        Instantiate(_projectile, hitpoint, Quaternion.identity);
        _swayStrength = SWAY_START;
        ApplyRecoil();
    }

    void ApplyRecoil()
    {
        float recoil = Random.Range(MIN_RECOIL, MAX_RECOIL);
        _scope.transform.position += new Vector3(recoil, recoil, 0);
    }

    public bool shot()
    {
        return _shoot.triggered;
    }

    private bool GameEnded()
    {
        if (_target.hitstate)
        {
            // Print different scores based on remaining ammo
            if (ammoAmount == 1)
            {
                _score = 100;
            }
            else if (ammoAmount == 2)
            {
                _score = 90;
            }
            else if (ammoAmount == 3)
            {
                _score = 70;
            }
            else if (ammoAmount == AMMO_AMOUNT)
            {
                _score = 10;
            }

            return true;
        }
        return false;
    }
}

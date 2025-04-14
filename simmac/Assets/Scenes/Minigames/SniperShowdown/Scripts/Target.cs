using UnityEngine;

public class Target : MonoBehaviour
{
    public float distance;
    public float windStrength;

    [SerializeField] private SniperShowdown _sniper;
    [SerializeField] private Collider2D _collider;

    private bool _beenHit = false;
    public bool hitstate { get; private set; }
    private float _travelTime;

    public const float SCALE_FACTOR = -0.15f;
    public const float SCALE_OFFSET = 3.85f;
    private const float MIN_DISTANCE = 3.0f;
    private const float MAX_DISTANCE = 12.0f;
    private const float MIN_WIND_STRENGTH = -8f;
    private const float MAX_WIND_STRENGTH = 8f;
    private const float TRAVEL_TIME_FACTOR = 0.01f;

    void Start()
    {
        InitializeTarget();
        hitstate = false;
    }

    void Update()
    {
        if (_beenHit)
        {
            HandleHit();
        }
        else
        {
            CheckForHit();
        }
    }

    private void InitializeTarget()
    {
        SetRandomTargetParameters();
        CalculateTravelTime();
        CalculateAndApplyScale();
    }

    private void SetRandomTargetParameters()
    {
        distance = Random.Range(MIN_DISTANCE, MAX_DISTANCE);
        windStrength = Random.Range(MIN_WIND_STRENGTH, MAX_WIND_STRENGTH);
    }

    private void CalculateTravelTime()
    {
        _travelTime = distance * TRAVEL_TIME_FACTOR;
    }

    private void CalculateAndApplyScale()
    {
        float scale = (distance * SCALE_FACTOR) + SCALE_OFFSET;
        transform.localScale = new Vector3(scale, scale, scale);
    }

    private void HandleHit()
    {
        UpdateTravelTime();
        CheckTravelTimeCompletion();
    }

    private void UpdateTravelTime()
    {
        if (_travelTime > 0)
        {
            _travelTime -= Time.deltaTime;
        }
    }

    private void CheckTravelTimeCompletion()
    {
        if (_travelTime <= 0)
        {
            hitstate = true;
        }
    }

    private void CheckForHit()
    {
        if (_sniper.shot() && _collider.OverlapPoint(_sniper.hitpoint))
        {
            _beenHit = true;
        }
    }
}

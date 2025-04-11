using UnityEngine;

public class Target : MonoBehaviour
{
    public float distance;
    public float windStrength;

    [SerializeField] private SniperShowdown _sniper;
    [SerializeField] private Collider2D _collider;

    private bool beenHit = false;
    public bool hitstate { get; private set; }
    private float _travelTime;

    public const float ScaleFactor = -0.15f;
    public const float ScaleOffset = 3.85f;
    private const float MinDistance = 3.0f;
    private const float MaxDistance = 12.0f;
    private const float MinWindStrength = -8f;
    private const float MaxWindStrength = 8f;
    private const float TravelTimeFactor = 0.01f;

    void Start()
    {
        InitializeTarget();
        hitstate = false;
    }

    void Update()
    {
        if (beenHit)
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
        distance = Random.Range(MinDistance, MaxDistance);
        windStrength = Random.Range(MinWindStrength, MaxWindStrength);
    }

    private void CalculateTravelTime()
    {
        _travelTime = distance * TravelTimeFactor;
    }

    private void CalculateAndApplyScale()
    {
        float scale = (distance * ScaleFactor) + ScaleOffset;
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
            beenHit = true;
        }
    }
}

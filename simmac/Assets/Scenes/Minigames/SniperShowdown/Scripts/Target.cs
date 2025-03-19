using UnityEngine;

public class Target : MonoBehaviour
{
    // public fields
    public float distance;
    public float windStrength;

    // serialized private fields
    [SerializeField] private Sniper _sniper;
    [SerializeField] private Collider2D _collider;

    // private fields
    private bool beenHit = false;
    private bool hitstate = false;
    private float _travelTime;

    // const values
    public const float ScaleFactor = -0.15f;
    public const float ScaleOffset = 3.85f;
    private const float MinDistance = 10f;
    private const float MaxDistance = 25f;
    private const float MinWindStrength = -8f;
    private const float MaxWindStrength = 8f;
    private const float TravelTimeFactor = 0.01f;

    void Start()
    {
        InitializeTarget();
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
        distance = Random.Range(MinDistance, MaxDistance);
        windStrength = Random.Range(MinWindStrength, MaxWindStrength);
        _travelTime = distance * TravelTimeFactor;
        float scale = (distance * ScaleFactor) + ScaleOffset;
        transform.localScale = new Vector3(scale, scale, scale);
    }

    private void HandleHit()
    {
        if (_travelTime > 0)
        {
            _travelTime -= Time.deltaTime;
        }
        else
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
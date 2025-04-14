using UnityEngine;

public class Bullet : MonoBehaviour
{
    public SpriteRenderer sprite;
    private float _travelTime;
    private float _scale;
    private const float SCALE_MULTIPLIER = 0.4f;
    private const float TRAVEL_TIME_MULTIPLIER = 0.01f;
    private Target _target;
    private Collider2D _targetCollider;

    void Start()
    {
        if (!FindAndValidateTarget())
        {
            return;
        }

        CalculateBulletProperties();
        InitializeBullet();
        CheckBulletHit();
    }

    void Update()
    {
        UpdateTravelTime();
        UpdateBulletAppearance();
    }

    private bool FindAndValidateTarget()
    {
        _target = GameObject.Find("Target")?.GetComponent<Target>();
        if (_target == null)
        {
            Debug.LogError("Target not found");
            return false;
        }

        _targetCollider = _target.GetComponent<Collider2D>();
        if (_targetCollider == null)
        {
            Debug.LogError("Collider2D not found on target");
            return false;
        }

        return true;
    }

    private void CalculateBulletProperties()
    {
        _scale = ((_target.distance * Target.SCALE_FACTOR) + Target.SCALE_OFFSET) * SCALE_MULTIPLIER;
        _travelTime = _target.distance * TRAVEL_TIME_MULTIPLIER;
    }

    private void InitializeBullet()
    {
        transform.localScale = Vector3.zero;
    }

    private void CheckBulletHit()
    {
        if (_targetCollider.OverlapPoint(transform.position))
        {
            sprite.color = Color.red;
        }
    }

    private void UpdateTravelTime()
    {
        _travelTime -= Time.deltaTime;
    }

    private void UpdateBulletAppearance()
    {
        if (_travelTime <= 0)
        {
            transform.localScale = new Vector3(_scale, _scale, _scale);
        }
    }
}

using UnityEngine;

public class Bullet : MonoBehaviour
{
    public SpriteRenderer sprite;

    //private fields
    private float _travelTime;
    private float _scale;

    // const fields
    private const float ScaleMultiplier = 0.4f;
    private const float TravelTimeFactor = 0.01f;

    void Start()
    {
        Target target = GameObject.Find("Target")?.GetComponent<Target>();
        if (target == null)
        {
            Debug.LogError("Target not found");
            return;
        }

        Collider2D collider = target.GetComponent<Collider2D>();
        if (collider == null)
        {
            Debug.LogError("Collider2D not found on target");
            return;
        }

        _scale = ((target.distance * Target.ScaleFactor) + Target.ScaleOffset) * ScaleMultiplier;
        _travelTime = target.distance * TravelTimeFactor;
        transform.localScale = Vector3.zero;

        if (collider.OverlapPoint(transform.position))
        {
            sprite.color = Color.red;
        }
    }

    void Update()
    {
        _travelTime -= Time.deltaTime;
        if (_travelTime <= 0)
        {
            transform.localScale = new Vector3(_scale, _scale, _scale);
        }
    }
}
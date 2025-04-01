using UnityEngine;

public class ShakeTimingBar : MonoBehaviour
{
    public float _scaleMultiplier = 0f;
    public bool _grow = true;
    private float _initialScale;
    private float _bottomY;
    private bool _freeze;

    void Start()
    {
        _initialScale = transform.localScale.y;
        _freeze = false;
        _bottomY = transform.position.y - (transform.localScale.y / 2f);
    }

    void Update()
    {
        if (_freeze) { return; }

        if (_scaleMultiplier <= 0)
        {
            _grow = true;
            _scaleMultiplier = 0f;
        }

        if (_scaleMultiplier >= 1)
        {
            _grow = false;
            _scaleMultiplier = 1;
        }

        float newScale = _initialScale * _scaleMultiplier;
        transform.localScale = new Vector3(transform.localScale.x, newScale, transform.localScale.z);

        float newHalfHeight = newScale / 2f;
        transform.position = new Vector3(transform.position.x,
                                        _bottomY + newHalfHeight,
                                        transform.position.z);

        if (Input.GetMouseButtonDown(0))
        {
            _freeze = true;
        }
    }

    void FixedUpdate()
    {
        if (_freeze) { return; }

        if (_grow)
        {
            _scaleMultiplier += 0.01f;
        }
        else
        {
            _scaleMultiplier -= 0.01f;
        }
    }
}

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
        InitializeVariables();
    }

    void Update()
    {
        if (_freeze) { return; }

        UpdateScalingDirection();
        UpdateBarScale();
        UpdateBarPosition();
        CheckForUserInput();
    }

    void FixedUpdate()
    {
        if (_freeze) { return; }

        UpdateScaleMultiplier();
    }

    private void InitializeVariables()
    {
        _initialScale = transform.localScale.y;
        _freeze = false;
        _bottomY = transform.position.y - (transform.localScale.y / 2f);
    }

    private void UpdateScalingDirection()
    {
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
    }

    private void UpdateBarScale()
    {
        float newScale = _initialScale * _scaleMultiplier;
        transform.localScale = new Vector3(transform.localScale.x, newScale, transform.localScale.z);
    }

    private void UpdateBarPosition()
    {
        float newHalfHeight = transform.localScale.y / 2f;
        transform.position = new Vector3(transform.position.x,
                                        _bottomY + newHalfHeight,
                                        transform.position.z);
    }

    private void CheckForUserInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _freeze = true;
        }
    }

    private void UpdateScaleMultiplier()
    {
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

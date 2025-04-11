using TMPro;
using UnityEngine;

public class ShakeShifter : MonoBehaviour
{
    public GameObject line;
    public GameObject shiftingBar; // aka the shifter
    public TextMeshProUGUI percentageUpdating;
    public TextMeshProUGUI percentageGoal;
    private float _percentageMultiplier;
    private float _maxScale = 7f;
    private bool _freeze;
    private int _difference;

    void Start()
    {
        InitializeVariables();
        SetupLinePosition();
    }

    void Update()
    {
        if (_freeze)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OATManager.AddOrderToOat(OrderableItem.Type.Milkshake, GameManager.instance.minigameModifier.modifier, GetScore(_difference));
                Destroy(transform.parent.gameObject);
                GameManager.instance.ToggleCameraAndCanvas();
                GameManager.instance.StartDayTime();
            }
            return;
        }

        UpdatePercentageDisplays();
        CheckForUserInput();
    }

    private void InitializeVariables()
    {
        _freeze = false;
        _percentageMultiplier = Random.Range(0, 100) * 0.01f;
    }

    private void SetupLinePosition()
    {
        line.transform.position = new Vector3(
            line.transform.position.x,
            line.transform.position.y + (_maxScale * _percentageMultiplier),
            line.transform.position.z);
    }

    private void UpdatePercentageDisplays()
    {
        float currentPercentage = CalculateCurrentPercentage();
        int roundedCurrentPercentage = Mathf.RoundToInt(currentPercentage);
        percentageUpdating.text = $"{roundedCurrentPercentage}%";

        int roundedGoalPercentage = Mathf.RoundToInt(_percentageMultiplier * 100f);
        percentageGoal.text = $"Click when {roundedGoalPercentage}%";
    }

    private float CalculateCurrentPercentage()
    {
        return (shiftingBar.transform.localScale.y / _maxScale) * 100f;
    }

    private void CheckForUserInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _freeze = true;
            line.gameObject.SetActive(true);
            DisplayResults();
        }
    }

    private void DisplayResults()
    {
        int currentPercentage = Mathf.RoundToInt(CalculateCurrentPercentage());
        int goalPercentage = Mathf.RoundToInt(_percentageMultiplier * 100f);
        _difference = Mathf.Abs(goalPercentage - currentPercentage);

        Debug.Log($"Goal: {goalPercentage}%, Current: {currentPercentage}%, Difference: {_difference}");
        percentageGoal.text = $"The goal was to get {goalPercentage}%, you clicked on {currentPercentage} which means you have a {_difference}% difference! This gives you a score of {GetScore(_difference)}%!";
    }

    int GetScore(int diff)
    {
        if (diff == 0)
        {
            return 100;
        }
        else if (diff > 2)
        {
            return 100 - 10 - diff;
        }
        else
        {
            // Add a default return value for other cases
            return Mathf.Max(0, 100 - diff); // Ensuring score doesn't go below 0
        }
    }
}

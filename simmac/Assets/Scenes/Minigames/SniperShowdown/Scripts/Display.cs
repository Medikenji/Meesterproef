using TMPro;
using UnityEngine;

public class Display : MonoBehaviour
{
    [SerializeField] private SniperShowdown _sniper;
    [SerializeField] private Target _target;

    private TextMeshProUGUI _windStats;
    private TextMeshProUGUI _calStats;
    private TextMeshProUGUI _ammoDisplay;

    void Start()
    {
        InitializeTextComponents();
    }

    void Update()
    {
        UpdateWindStats();
        UpdateCalibrationStats();
        UpdateAmmoDisplay();
    }

    private void InitializeTextComponents()
    {
        _windStats = FindTextComponent("Wind Stats");
        _calStats = FindTextComponent("Calibration Stats");
        _ammoDisplay = FindTextComponent("Ammo Display");
    }

    private TextMeshProUGUI FindTextComponent(string objectName)
    {
        GameObject temp = GameObject.Find(objectName);
        return temp.GetComponent<TextMeshProUGUI>();
    }

    private void UpdateWindStats()
    {
        _windStats.text = "Target is " + (int)_target.distance + " units away, and there is a wind with a strength of " + (int)_target.windStrength;
    }

    private void UpdateCalibrationStats()
    {
        _calStats.text = "Distance calibration: " + _sniper.distanceCal.ToString("F1") + "\nWind calibration: " + _sniper.windCal.ToString("F1");
    }

    private void UpdateAmmoDisplay()
    {
        _ammoDisplay.text = FormatAmmoDisplay();
    }

    private string FormatAmmoDisplay()
    {
        string text = "";
        for (int i = 0; i < _sniper.ammoAmount; i++)
        {
            text += "| ";
        }
        return text;
    }
}

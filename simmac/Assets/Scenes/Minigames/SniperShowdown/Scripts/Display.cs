using TMPro;
using UnityEngine;

public class Display : MonoBehaviour
{

    // serialized private fields
    [SerializeField]
    private Sniper _sniper;
    [SerializeField]
    private Target _target;

    // private fields
    private TextMeshProUGUI _windStats;
    private TextMeshProUGUI _calStats;
    private TextMeshProUGUI _ammoDisplay;
    void Start()
    {
        GameObject temp;
        temp = GameObject.Find("Wind Stats");
        _windStats = temp.GetComponent<TextMeshProUGUI>();
        temp = GameObject.Find("Calibration Stats");
        _calStats = temp.GetComponent<TextMeshProUGUI>();
        temp = GameObject.Find("Ammo Display");
        _ammoDisplay = temp.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _windStats.text = "Target is " + (int)_target.distance + " units away, and there is a wind with a strength of " + (int)_target.windStrength;
        _calStats.text = "Distance calibration: " + _sniper.distanceCal.ToString("F1") + "\nWind calibration: " + _sniper.windCal.ToString("F1");
        _ammoDisplay.text = AmmoFormatting(); 
    }

    string AmmoFormatting()
    {
        string text = "";
        for (int i = 0; i < _sniper.ammoAmount; i++)
        {
            text += "| ";
        }
        return text;
    }
}

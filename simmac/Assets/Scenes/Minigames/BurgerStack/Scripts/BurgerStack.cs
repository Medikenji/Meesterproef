using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.Collections;
using UnityEngine.UIElements;

public class BurgerStack : MonoBehaviour
{
    public List<BurgerIngredient> ingredients;
    private float _realPercentage;
    private int _scoredPercentage;
    private float _totalPercentage;
    public TextMeshProUGUI textField;
    private bool _textTriggered = false;

    void Start()
    {
        textField.enabled = false;
    }

    void Update()
    {
        CalculateStackScore();
        RenderText();
        DisplayText();

        if (_textTriggered)
        {
            ReturnToGameIfEscPressed();
        }
    }

    private void CalculateStackScore()
    {
        if (ingredients != null && ingredients.Count > 0)
        {
            _totalPercentage = 0;
            Vector3 firstPosition = ingredients[0].transform.position;

            for (int i = 0; i < ingredients.Count; i++)
            {
                if (ingredients[i] == null) continue;

                // Calculate absolute X difference
                float xDifference = Mathf.Abs(ingredients[i].transform.position.x - firstPosition.x);

                // Calculate percentage based on the scale of 5.5
                float percentage = Mathf.Clamp01(1f - (xDifference / 5.5f));

                _totalPercentage += percentage;
            }
        }
    }

    private void RenderText()
    {
        // Calculate the average percentage
        _realPercentage = _totalPercentage / ingredients.Count;

        if (_realPercentage > 0.95f)
        {
            _scoredPercentage = 100;
        }
        else if (_realPercentage > 0.90f)
        {
            _scoredPercentage = 90;
        }
        else if (_realPercentage > 0.85f)
        {
            _scoredPercentage = 80;
        }
        else if (_realPercentage > 0.80f)
        {
            _scoredPercentage = 70;
        }
        else
        {
            _scoredPercentage = 60;
        }

        textField.text = $"You stacked the burger {_realPercentage * 100:F1}% effectively!\nYou get a score of {_scoredPercentage}!";
    }

    private void DisplayText()
    {
        if (ingredients.Count > 0 && ingredients[ingredients.Count - 1].movesWithPlayer == true && !_textTriggered)
        {
            _textTriggered = true;
        }

        if (_textTriggered)
        {
            textField.enabled = true;
            StartCoroutine(WaitForSeconds(2));
        }
    }

    IEnumerator WaitForSeconds(int s)
    {
        yield return new WaitForSeconds(s);
        textField.enabled = true;
    }

    private void ReturnToGameIfEscPressed()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(SceneStation.ReturnToMainScene());
        }
    }
}

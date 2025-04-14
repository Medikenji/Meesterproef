using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class PFIB : MonoBehaviour
{
    public GameObject fry;
    public int friesToCreate;
    public TextMeshProUGUI gameText;
    public TextMeshProUGUI scoreText;
    private int _fryCount;
    [SerializeField] private List<GameObject> _fries;
    [SerializeField] private bool _gameEnded = false;
    private int _n;

    void Start()
    {
        GenerateFriesAmount();
    }

    void Update()
    {
        DeleteFryFromListIfBelowTheScreen();
        if (GameFinished())
        {
            EndGame();
        }

        if (_gameEnded)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log(GameManager.instance.minigameModifier.modifier);
                OATManager.AddOrderToOat(OrderableItem.Type.Fries, GameManager.instance.minigameModifier.modifier, _fries.Count / friesToCreate * 100);
                Destroy(transform.parent.gameObject);
                GameManager.instance.ToggleCameraAndCanvas();
                GameManager.instance.StartDayTime();
            }
        }
    }

    void FixedUpdate()
    {
        if (++_n != 7) { return; }
        if (_fryCount >= friesToCreate) { return; }

        CreateFryAndTrackInList();

        _n = 0;
    }

    private bool GameFinished()
    {
        return _fryCount == friesToCreate && !_gameEnded;
    }

    private bool EndGame()
    {
        if (_gameEnded) { return true; }

        _gameEnded = GameFinished();
        StartCoroutine(GameEnd(friesToCreate / 4));

        return _gameEnded;
    }

    private void DeleteFryFromListIfBelowTheScreen()
    {
        for (int i = _fries.Count - 1; i >= 0; i--)
        {
            if (_fries[i].transform.position.y <= 1100)
            {
                GameObject fryToRemove = _fries[i];
                _fries.RemoveAt(i);
                Destroy(fryToRemove);
            }
        }
    }

    private void GenerateFriesAmount()
    {
        friesToCreate = Random.Range(friesToCreate - 10, friesToCreate + 10);
    }

    void CreateFryAndTrackInList()
    {
        if (_fries.Count == 0)
        {
            int randX = Random.Range(-8, 8);

            GameObject tempFry = Instantiate(fry, new Vector3(1133, 1143, 3), Quaternion.identity);
            _fries.Add(tempFry);
        }
        else
        {
            Vector3 prevPosition = _fries[_fries.Count - 1].transform.position;

            float offset = Random.Range(-2f, 2f);
            float newX = Mathf.Clamp(prevPosition.x + offset, -8f, 8f);

            GameObject tempFry = Instantiate(fry, new Vector3(1133, 1143, 3), Quaternion.identity);
            _fries.Add(tempFry);
        }
        _fryCount++;
    }

    IEnumerator GameEnd(int WaitForSeconds)
    {
        yield return new WaitForSeconds(WaitForSeconds);

        int friesCaught = _fries.Count;

        gameText.text = $"You caught {friesCaught}/{friesToCreate} fries!";
        scoreText.text = $"You get a score of {(float)friesCaught / friesToCreate * 100:F0}%!";

        scoreText.gameObject.SetActive(true);
    }
}

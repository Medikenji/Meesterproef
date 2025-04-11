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
        GenerateBagSize();
    }

    void Update()
    {
        DeleteFryFromListIfBelowTheScreen();
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
        if (_gameEnded) { return true;}

        _gameEnded = GameFinished();
        StartCoroutine(GameEnd(friesToCreate / 4));

        return _gameEnded;
    }

    private void DeleteFryFromListIfBelowTheScreen()
    {
        for (int i = _fries.Count - 1; i >= 0; i--)
        {
            if (_fries[i].transform.position.y <= -10)
            {
                GameObject fryToRemove = _fries[i];
                _fries.RemoveAt(i);
                Destroy(fryToRemove);
            }
        }
    }

    private void GenerateBagSize()
    {
        friesToCreate = Random.Range(friesToCreate - 10, friesToCreate + 10);
    }

    void CreateFryAndTrackInList()
    {
        if (_fries.Count == 0)
        {
            int randX = Random.Range(-8, 8);

            GameObject tempFry = Instantiate(fry, new Vector3(randX, 10, 0), Quaternion.identity);
            _fries.Add(tempFry);
        }
        else
        {
            Vector3 prevPosition = _fries[_fries.Count - 1].transform.position;

            float offset = Random.Range(-2f, 2f);
            float newX = Mathf.Clamp(prevPosition.x + offset, -8f, 8f);

            GameObject tempFry = Instantiate(fry, new Vector3(newX, 10, 0), Quaternion.identity);
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

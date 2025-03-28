using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PFIB : MonoBehaviour
{
    public GameObject fry;
    public List<GameObject> fries;
    public int friesToCreate;
    private int _fryCount;
    private int _n;
    void Start()
    {

    }

    void Update()
    {
        for (int i = fries.Count - 1; i >= 0; i--)
        {
            if (fries[i].transform.position.y <= -10)
            {
                GameObject fryToRemove = fries[i];
                fries.RemoveAt(i);
                Destroy(fryToRemove);
            }
        }

        if (_fryCount == friesToCreate)
        {
            StartCoroutine(Timeout(10));
            print($"You got {fries.Count}");
        }
    }

    void FixedUpdate()
    {
        if (++_n != 7) { return; }
        if (_fryCount >= friesToCreate) { return; }

        CreateFryAndTrackInList();

        _n = 0;
    }

    void CreateFryAndTrackInList()
    {
        if (fries.Count == 0)
        {
            int randX = Random.Range(-8, 8);

            GameObject tempFry = Instantiate(fry, new Vector3(randX, 10, 0), Quaternion.identity);
            fries.Add(tempFry);
        }
        else
        {
            Vector3 prevPosition = fries[fries.Count - 1].transform.position;

            float offset = Random.Range(-2f, 2f);
            float newX = Mathf.Clamp(prevPosition.x + offset, -8f, 8f);

            GameObject tempFry = Instantiate(fry, new Vector3(newX, 10, 0), Quaternion.identity);
            fries.Add(tempFry);
        }
        _fryCount++;
    }

    IEnumerator Timeout(int s)
    {
        yield return new WaitForSeconds(s);
    }
}

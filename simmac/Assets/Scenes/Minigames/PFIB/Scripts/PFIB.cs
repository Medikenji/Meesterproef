using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PFIB : MonoBehaviour
{
    public GameObject fry;
    public List<GameObject> fries;
    public int friesToCreate;
    private int _n;
    private int _yPosNewFry = 10;
    void Start()
    {

    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if (++_n != 5) { return; }
        if (fries.Count >= friesToCreate) { return; }

        CreateFryAndTrackInList();

        _n = 0;
    }

    void CreateFryAndTrackInList()
    {
        if (fries.Count == 0)
        {
            int randX = Random.Range(-8, 8);
            _yPosNewFry += 6;

            GameObject tempFry = Instantiate(fry, new Vector3(randX, _yPosNewFry, 0), Quaternion.identity);
            fries.Add(tempFry);
        }
        else
        {
            Vector3 prevPosition = fries[fries.Count - 1].transform.position;

            float offset = Random.Range(-2f, 2f);
            float newX = Mathf.Clamp(prevPosition.x + offset, -8f, 8f);

            _yPosNewFry += 6;

            GameObject tempFry = Instantiate(fry, new Vector3(newX, _yPosNewFry, 0), Quaternion.identity);
            fries.Add(tempFry);
        }
    }
}

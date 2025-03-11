using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    void Start()
    {

    }

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameManager();
            return _instance;
        }
    }

    void Update()
    {

    }
}

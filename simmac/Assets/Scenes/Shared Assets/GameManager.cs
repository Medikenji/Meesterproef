using System.IO;
using MessagePack;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private static string filePath;

    [MessagePackObject]
    public struct _GameState
    {
        [Key(0)]
        public bool is_current_game;
        [Key(1)]
        public bool game_over;
        [Key(2)]
        public int current_day;
        [Key(3)]
        public float money;
        [Key(4)]
        public int customers_served;
    }
    _GameState current_state;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "savegame.simmac");
        _instance.current_state = loadCurrentGame();
        saveCurrentGame();
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

    private _GameState loadCurrentGame()
    {
        try
        {
            return MessagePackSerializer.Deserialize<_GameState>(File.ReadAllBytes(filePath));
        }
        catch
        {
            return new _GameState { is_current_game = false, game_over = false, current_day = 0, money = 0.0f, customers_served = 0 };
        }
    }

    public static void saveCurrentGame()
    {
        byte[] bytes = MessagePackSerializer.Serialize(_instance.current_state);
        File.WriteAllBytes(filePath, bytes);
    }
}

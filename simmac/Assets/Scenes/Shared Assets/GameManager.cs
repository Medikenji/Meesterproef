using System.Collections.Generic;
using System.IO;
using MessagePack;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // public fields
    public _GameState current_state;
    public List<Order> orders;

    // private fields
    private static GameManager _instance;
    private static string _mainSavePath;

    void Start()
    {
        _mainSavePath = Path.Combine(Application.persistentDataPath, "savegame.simmac");
        _instance.current_state = loadCurrentGame();
        saveCurrentGame();
    }

    void Update()
    {

    }

    public static GameManager instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameManager();
            return _instance;
        }
    }

    // ############### Start savegame functions ###############
    private _GameState loadCurrentGame()
    {
        try
        {
            return MessagePackSerializer.Deserialize<_GameState>(File.ReadAllBytes(_mainSavePath));
        }
        catch
        {
            return new _GameState { is_current_game = false, game_over = false, current_day = 0, money = 0.0f, customers_served = 0 };
        }
    }

    public static void saveCurrentGame()
    {
        byte[] bytes = MessagePackSerializer.Serialize(instance.current_state);
        File.WriteAllBytes(_mainSavePath, bytes);
    }

    // ############### End savegame functions ###############


    // ############### Structs ###############

    /// <summary>
    /// A struct that stores everything needed for saving and loading a game
    /// </summary>
    [MessagePackObject]
    public struct _GameState
    {
        [Key(1)]
        public bool is_current_game;
        [Key(2)]
        public bool game_over;
        [Key(3)]
        public int current_day;
        [Key(4)]
        public float money;
        [Key(5)]
        public int customers_served;
    }
}

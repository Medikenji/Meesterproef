using System.Collections.Generic;
using System.IO;
using MessagePack;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // public fields
    public _GameState current_state;
    [SerializeField]
    public List<Order> orders = new List<Order>();
    public float dayTimeLeft { get; private set; }
    public EventHandler eventHandler;
    public int customerAmount;

    // private fields
    private static GameManager _instance = null;
    private static string _mainSavePath;
    private bool _passTime;

    // const fields
    public const float dayDurationInSeconds = 300;

    void Start()
    {
        _mainSavePath = Path.Combine(Application.persistentDataPath, "savegame.simmac");
        instance.current_state = loadCurrentGame();
        StartOfDay();
    }

    void Update()
    {
        HandleDayTime();
    }

    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("GameManager").AddComponent<GameManager>();
                Debug.Log("Created GameManager instance");
            }
            return _instance;
        }
    }

    public void StartOfDay()
    {
        customerAmount = 0;
        dayTimeLeft = dayDurationInSeconds;
        _passTime = true;
    }
    private void EndOfDay()
    {
        StopDayTime();
        if (customerAmount > 0)
        {
            return;
        }
        saveCurrentGame();
    }

    private void HandleDayTime()
    {
        if (_passTime)
        {
            dayTimeLeft -= Time.deltaTime;
        }
        if (dayTimeLeft <= 0)
        {
            EndOfDay();
        }

    }

    #region  DayTime functions
    public void StartDayTime()
    {
        _passTime = true;
    }
    public void StopDayTime()
    {
        _passTime = false;
    }

    public void SkipDayTime(float amountOfSeconds)
    {
        dayTimeLeft -= amountOfSeconds;
    }

    public void ToggleDayTime()
    {
        _passTime = !_passTime;
    }

    #endregion

    #region  SaveGame functions

    private _GameState loadCurrentGame()
    {
        try
        {
            return MessagePackSerializer.Deserialize<_GameState>(File.ReadAllBytes(_mainSavePath));
        }
        catch
        {
            return new _GameState { is_current_game = false, game_over = false, current_day = 0, money = 0.0f, customers_served = 0, stars = 1 };
        }
    }

    public static void saveCurrentGame()
    {
        byte[] bytes = MessagePackSerializer.Serialize(instance.current_state);
        File.WriteAllBytes(_mainSavePath, bytes);
    }

    #endregion

    #region  Structs

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
        [Key(6)]
        public float stars;
    }

    #endregion
}

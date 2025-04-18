using System.Collections.Generic;
using System.IO;
using MessagePack;
using UnityEngine;
using UnityEngine.SceneManagement;

// Singleton my beloved <3
public class GameManager : MonoBehaviour
{
    public _GameState current_state;
    public List<Order> orders = new List<Order>();
    public float dayTimeLeft { get; private set; }
    public EventHandler eventHandler;
    public int customerAmount = 0;
    public string ActiveAdditiveScene;
    public bool passTime { get; private set; }
    public MinigameModifier minigameModifier;
    public bool ignoreStationClick = false;

    public const float DAY_DURATION_SECONDS = 180;

    private static GameManager _instance = null;
    private GameObject customerPrefab;
    private static string _mainSavePath;
    private float _customerCountdown = 5;
    private GameObject _mainCamera;
    private GameObject _mainCanvas;


    private void Awake()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        _mainCanvas = GameObject.FindGameObjectWithTag("Main UI");

        customerPrefab = Resources.Load<GameObject>("Customer");
        if (customerPrefab == null)
        {
            Debug.LogError("Customer could not be found in Resources folder.");
        }
    }

    public void LoadGame()
    {
        _mainSavePath = Path.Combine(Application.persistentDataPath, "savegame.simmac");
        instance.current_state = loadCurrentGame();
        saveCurrentGame();
    }

    void Start()
    {
        LoadGame();
        if (current_state.state == State.InGame || current_state.state == State.NewSave)
        {
            StartOfDay();
        }
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
                Debug.Log(OATManager.instance + "Creating OATManager");

            }
            return _instance;
        }
    }

    public void ToggleCameraAndCanvas()
    {
        _mainCamera.SetActive(!_mainCamera.activeSelf);
        _mainCanvas.SetActive(!_mainCanvas.activeSelf);
    }

    public void StartOfDay()
    {
        customerAmount = 0;
        dayTimeLeft = DAY_DURATION_SECONDS;
        passTime = true;
    }
    private void EndOfDay()
    {
        StopDayTime();
        if (customerAmount > 0)
        {
            return;
        }
        orders.Clear();
        OATManager.instance.clearAllItems();
        if (current_state.money < -100)
        {
            current_state.state = State.GameOver;
        }
        else
        {
            current_state.state = State.InMenu;
        }
        saveCurrentGame();
        SceneManager.LoadScene("MenuScene");
    }

    private void HandleDayTime()
    {
        if (passTime)
        {
            dayTimeLeft -= Time.deltaTime;
            _customerCountdown -= Time.deltaTime;

            if (_customerCountdown <= 0)
            {
                SummonCustomers();
                _customerCountdown = Random.Range(5, 35);
            }
        }

        if (dayTimeLeft <= 0)
        {
            EndOfDay();
        }

    }

    private void SummonCustomers()
    {
        int randomAmount = Random.Range(1, 4);
        for (int i = 0; i < randomAmount; i++)
        {
            Instantiate(customerPrefab);
        }
    }

    #region  DayTime functions

    public void StartDayTime()
    {
        passTime = true;
    }
    public void StopDayTime()
    {
        passTime = false;
    }

    public void SkipDayTime(float amountOfSeconds)
    {
        dayTimeLeft -= amountOfSeconds;
    }

    public void ToggleDayTime()
    {
        passTime = !passTime;
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
            return new _GameState { is_current_game = false, state = State.NewSave, current_day = 0, money = 1000.0f, customers_served = 0, stars = 1, reviewAmount = 1 };
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
        public State state;
        [Key(3)]
        public int current_day;
        [Key(4)]
        public float money;
        [Key(5)]
        public int customers_served;
        [Key(6)]
        public float stars;
        [Key(7)]
        public int reviewAmount;
    }

    public enum State
    {
        NewSave,
        InGame,
        InMenu,
        GameOver
    }

    public struct MinigameModifier
    {
        public OrderableItem.Type type;
        public OrderableItem.Modifier modifier;
    }

    #endregion
}

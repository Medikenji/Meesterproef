using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class MinigameScreenManager : MonoBehaviour
{
    public Button regularBtn, redBtn, greenBtn, blueBtn, exitBtn;
    [SerializeField] private GameObject _burgerStack, _PFIB, _shakeShifter, _sniperShowdown;

    void Start()
    {
        _burgerStack = Resources.Load<GameObject>("BurgerStack Minigame");
        _PFIB = Resources.Load<GameObject>("PFIB Minigame");
        _shakeShifter = Resources.Load<GameObject>("ShakeShifter Minigame");
        _sniperShowdown = Resources.Load<GameObject>("SniperShowdown Minigame");

        regularBtn.onClick.AddListener(() => StartMinigame(
            GameManager.instance.minigameModifier.type,
            OrderableItem.Modifier.Default
            ));

        redBtn.onClick.AddListener(() => StartMinigame(
            GameManager.instance.minigameModifier.type,
            OrderableItem.Modifier.Red
            ));

        greenBtn.onClick.AddListener(() => StartMinigame(
            GameManager.instance.minigameModifier.type,
            OrderableItem.Modifier.Green)
            );

        blueBtn.onClick.AddListener(() => StartMinigame(
            GameManager.instance.minigameModifier.type,
            OrderableItem.Modifier.Blue
            ));

        exitBtn.onClick.AddListener(() =>
        {
            StartCoroutine(UnloadAdditiveScene());
            GameManager.instance.StartDayTime();
        });
    }

    public void StartMinigame(OrderableItem.Type type, OrderableItem.Modifier mod)
    {
        GameManager.instance.minigameModifier.modifier = mod;
        switch (type)
        {
            case OrderableItem.Type.Burger:
                StartCoroutine(UnloadAdditiveScene());
                Instantiate(_burgerStack);
                break;
            case OrderableItem.Type.Fries:
                StartCoroutine(UnloadAdditiveScene());
                Instantiate(_PFIB);
                break;
            case OrderableItem.Type.Milkshake:
                StartCoroutine(UnloadAdditiveScene());
                Instantiate(_shakeShifter);
                break;
            case OrderableItem.Type.Icecream:
                StartCoroutine(UnloadAdditiveScene());
                Instantiate(_sniperShowdown);
                break;
            default:
                break;
        }

        GameManager.instance.ToggleCameraAndCanvas();
    }

    public IEnumerator UnloadAdditiveScene()
    {
        GameManager.instance.ignoreStationClick = false;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("GameScene"));

        if (string.IsNullOrEmpty(GameManager.instance.ActiveAdditiveScene))
        {
            Debug.LogWarning("No active additive scene to unload.");
            yield break;
        }

        AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(GameManager.instance.ActiveAdditiveScene);

        GameManager.instance.ActiveAdditiveScene = null;

        while (!asyncUnload.isDone)
        {
            yield return null;
        }
    }
}

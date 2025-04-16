using TMPro;
using UnityEngine;

public class MenuBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI info;
    void Start()
    {
        GameManager.instance.LoadGame();
        int day = GameManager.instance.current_state.current_day;
        float money = GameManager.instance.current_state.money;
        int totalCustomersServed = GameManager.instance.current_state.customers_served;
        float rating = GameManager.instance.current_state.stars;
        bool isGameOver = false;

        if (GameManager.instance.current_state.state == GameManager.State.GameOver)
        {
            isGameOver = true;
        }


        if (isGameOver)
        {
            info.text = $"Day: {day}\nCurrent rating: {rating} \nMoney: {money}\nTotal Customers Served: {totalCustomersServed}\nGame Over";
        }

        info.text = $"Day: {day}\nCurrent rating: {rating}\nMoney: {money}\nTotal Customers Served: {totalCustomersServed}";
    }
}

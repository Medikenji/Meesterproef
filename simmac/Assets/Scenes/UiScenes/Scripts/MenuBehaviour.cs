using TMPro;
using UnityEngine;

public class MenuBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI info;
    void Start()
    {
        int day = GameManager.instance.current_state.current_day;
        float money = GameManager.instance.current_state.money;
        int totalCustomersServed = GameManager.instance.current_state.customers_served;
        bool isGameOver = false;

        if (GameManager.instance.current_state.state == GameManager.State.GameOver)
        {
            isGameOver = true;
        }


        if (isGameOver)
        {
            info.text = $"Day: {day}\nMoney: {money}\nTotal Customers Served: {totalCustomersServed}\nGame Over";
        }

        info.text = $"Day: {day}\nMoney: {money}\nTotal Customers Served: {totalCustomersServed}";
    }
}

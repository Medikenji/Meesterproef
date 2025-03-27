using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject orderPrefab;
    [SerializeField]
    private GameObject orderItemPrefab;
    [SerializeField]
    private TextMeshProUGUI moneyText;
    [SerializeField]
    private TextMeshProUGUI dayText;
    static private bool instantiated = false;

    // make sure the restaurant isnt open after 24:00 because the clock really isnt made for that
    private const int dayDurationInHours = 15;
    private const int openingTimeHour = 9;
    void Update()
    {
        FormatTimeText();
        FormatMoneyText();
        InstantiateOrders();
    }

    void FormatTimeText()
    {
        float metricTime = GameManager.instance.dayTimeLeft;
        int totalMinutes = Mathf.FloorToInt((GameManager.dayDurationInSeconds - metricTime) / GameManager.dayDurationInSeconds * dayDurationInHours * 60);
        int hours = openingTimeHour + totalMinutes / 60;
        int minutes = totalMinutes % 60;
        dayText.text = $"{hours:D2}:{minutes:D2}";
    }

    void FormatMoneyText()
    {
        moneyText.text = "€" + GameManager.instance.current_state.money.ToString("F2");
    }

    #region OrderFunctions
    public static void UpdateOrderAmount()
    {
        instantiated = false;
    }

    void InstantiateOrders()
    {
        if (instantiated) return;
        foreach (Transform child in transform)
        {
            if (child.gameObject == moneyText.gameObject || child.gameObject == dayText.gameObject)
                continue;
            Destroy(child.gameObject);
        }
        int maxOrders = Mathf.Min(GameManager.instance.orders.Count, 10);
        for (int i = 0; i < maxOrders; i++)
        {
            GameObject order = Instantiate(orderPrefab, transform);
            createOrderSquare(ref order, i);
        }
        instantiated = true;
    }
    private void createOrderSquare(ref GameObject order, int i)
    {
        TextMeshProUGUI text = order.GetComponentInChildren<TextMeshProUGUI>();
        text.text = "#Order " + i;
        RectTransform rectTransform = order.GetComponent<RectTransform>();
        rectTransform.SetParent(transform, false);
        int row = i / 5;
        int column = i % 5;
        rectTransform.anchoredPosition = new Vector2(100 + column * 200, -100 - row * 250);
        createOrderContent(ref order, i);
    }

    private void createOrderContent(ref GameObject order, int i)
    {
        Order currentOrder = GameManager.instance.orders[i];
        for (int j = 0; j < currentOrder._orderableItems.Count; j++)
        {
            GameObject item = Instantiate(orderItemPrefab, order.transform);
            UnityEngine.UI.Image image = item.GetComponent<UnityEngine.UI.Image>();
            image.color = currentOrder._orderableItems[j].modifier switch
            {
                OrderableItem.Modifier.Default => Color.white,
                OrderableItem.Modifier.Red => Color.red,
                OrderableItem.Modifier.Green => Color.green,
                OrderableItem.Modifier.Blue => Color.cyan,
                _ => Color.black,
            };
            RectTransform rectTransform = item.GetComponent<RectTransform>();
            rectTransform.SetParent(order.transform);
            int row = j / 4;
            int column = j % 4;
            rectTransform.anchoredPosition = new Vector2(25 + column * 50, -25 - row * 50);
        }
    }
    #endregion
}

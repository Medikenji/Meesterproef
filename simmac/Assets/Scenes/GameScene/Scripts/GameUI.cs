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

    [SerializeField]
    private Sprite burgerSprite;
    [SerializeField]
    private Sprite friesSprite;
    [SerializeField]
    private Sprite milkshakeSprite;
    [SerializeField]
    private Sprite dessertSprite;

    static private bool instantiated;

    // make sure the restaurant isnt open after 24:00 because the clock really isnt made for that
    private const int dayDurationInHours = 15;
    private const int openingTimeHour = 9;

    void Update()
    {
        UpdateTimeDisplay();
        UpdateMoneyDisplay();
        UpdateOrdersDisplay();
    }

    private void UpdateTimeDisplay()
    {
        float metricTime = GameManager.instance.dayTimeLeft;
        int totalMinutes = CalculateTotalMinutes(metricTime);
        int hours = openingTimeHour + totalMinutes / 60;
        int minutes = totalMinutes % 60;
        dayText.text = $"{hours:D2}:{minutes:D2}";
    }

    private int CalculateTotalMinutes(float metricTime)
    {
        return Mathf.FloorToInt((GameManager.dayDurationInSeconds - metricTime) /
                               GameManager.dayDurationInSeconds * dayDurationInHours * 60);
    }

    private void UpdateMoneyDisplay()
    {
        moneyText.text = "€" + GameManager.instance.current_state.money.ToString("F2");
    }

    #region OrderFunctions
    public static void RefreshOrderDisplay()
    {
        instantiated = false;
    }

    private void UpdateOrdersDisplay()
    {
        if (instantiated) return;

        ClearExistingOrders();
        CreateNewOrderDisplays();

        instantiated = true;
    }

    private void ClearExistingOrders()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject == moneyText.gameObject || child.gameObject == dayText.gameObject)
                continue;
            Destroy(child.gameObject);
        }
    }

    private void CreateNewOrderDisplays()
    {
        int maxOrders = Mathf.Min(GameManager.instance.orders.Count, 6);
        for (int i = 0; i < maxOrders; i++)
        {
            GameObject order = Instantiate(orderPrefab, transform);
            SetupOrderDisplay(ref order, i);
        }
    }

    private void SetupOrderDisplay(ref GameObject order, int orderIndex)
    {
        SetupOrderHeader(order, orderIndex);
        PositionOrderDisplay(order, orderIndex);
        CreateOrderItemsDisplay(order, orderIndex);
    }

    private void SetupOrderHeader(GameObject order, int orderIndex)
    {
        TextMeshProUGUI text = order.GetComponentInChildren<TextMeshProUGUI>();
        text.text = "#Order " + (orderIndex + 1);
    }

    private void PositionOrderDisplay(GameObject order, int orderIndex)
    {
        RectTransform rectTransform = order.GetComponent<RectTransform>();
        rectTransform.SetParent(transform, false);
        int row = orderIndex / 3;
        int column = orderIndex % 3;
        rectTransform.anchoredPosition = new Vector2(100 + column * 200, -100 - row * 250);
    }

    private void CreateOrderItemsDisplay(GameObject order, int orderIndex)
    {
        Order currentOrder = GameManager.instance.orders[orderIndex];
        for (int j = 0; j < currentOrder.orderableItems.Count; j++)
        {
            CreateOrderItemDisplay(order, currentOrder, j);
        }
    }

    private void CreateOrderItemDisplay(GameObject order, Order currentOrder, int itemIndex)
    {
        OrderableItem item = currentOrder.orderableItems[itemIndex];
        GameObject itemDisplay = Instantiate(orderItemPrefab, order.transform);

        UnityEngine.UI.Image image = itemDisplay.GetComponent<UnityEngine.UI.Image>();
        image.color = GetColorForModifier(item.modifier);
        image.sprite = GetSpriteForItemType(item.type);
        if (item.state == Order.State.Oat)
        {
            image.color = Color.black;
        }

        PositionOrderItem(itemDisplay, order, itemIndex);
    }

    private void PositionOrderItem(GameObject itemDisplay, GameObject order, int itemIndex)
    {
        RectTransform rectTransform = itemDisplay.GetComponent<RectTransform>();
        rectTransform.SetParent(order.transform);
        int row = itemIndex / 4;
        int column = itemIndex % 4;
        rectTransform.anchoredPosition = new Vector2(25 + column * 50, -25 - row * 50);
    }

    private Color GetColorForModifier(OrderableItem.Modifier modifier)
    {
        return modifier switch
        {
            OrderableItem.Modifier.Default => Color.white,
            OrderableItem.Modifier.Red => Color.red,
            OrderableItem.Modifier.Green => Color.green,
            OrderableItem.Modifier.Blue => Color.cyan,
            _ => Color.black,
        };
    }

    private Sprite GetSpriteForItemType(OrderableItem.Type type)
    {
        return type switch
        {
            OrderableItem.Type.Burger => burgerSprite,
            OrderableItem.Type.Fries => friesSprite,
            OrderableItem.Type.Milkshake => milkshakeSprite,
            OrderableItem.Type.Icecream => dessertSprite,
            _ => null
        };
    }
    #endregion
}

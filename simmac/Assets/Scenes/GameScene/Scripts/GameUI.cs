using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject orderPrefab;
    [SerializeField]
    private GameObject orderItemPrefab;
    static private bool instantiated = false;
    void Update()
    {
        if (!instantiated)
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            for (int i = 0; i < GameManager.instance.orders.Count; i++)
            {
                GameObject order = Instantiate(orderPrefab, transform);
                createOrderSquare(ref order, i);
                if (i > 10)
                {
                    break;
                }
            }
            instantiated = true;
        }
    }

    public static void UpdateOrderAmount()
    {
        instantiated = false;
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
        Debug.Log(currentOrder._orderableItems.Count);
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
}

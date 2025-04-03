using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OATManager : MonoBehaviour
{
    private static OATManager _instance = null;
    public List<OrderableItem> items { get; private set; } = new List<OrderableItem>();
    private static bool _recheck = true;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_recheck)
        {
            handleOrders();
            _recheck = false;
            GameUI.RefreshOrderDisplay();
        }
    }

    static public void AddOrderToOat(OrderableItem.Type type, OrderableItem.Modifier modifier, float quality)
    {
        OrderableItem item = new OrderableItem(type, modifier, setQuality: quality);
        instance.items.Add(item);
        recheckOrders();
    }
    void handleOrders()
    {
        if (GameManager.instance.orders == null || instance.items == null)
            return;
        foreach (Order order in GameManager.instance.orders)
        {
            if (order.state != Order.State.Waiting || order.orderableItems == null)
                continue;

            for (int i = 0; i < order.orderableItems.Count; i++)
            {
                OrderableItem orderItem = order.orderableItems[i];
                Debug.Log($"OrderableItem: Type={orderItem.type}, Modifier={orderItem.modifier}, State={orderItem.state}, Quality={orderItem.quality}");
                if (orderItem.state != Order.State.Waiting)
                    continue;

                var matchingItem = instance.items.FirstOrDefault(item => item.type == orderItem.type && item.modifier == orderItem.modifier);
                if (matchingItem != null)
                {
                    order.orderableItems[i] = matchingItem;
                    instance.items.Remove(matchingItem);
                    order.orderableItems[i].state = Order.State.Oat;
                }
            }
        }
    }
    static public void recheckOrders()
    {
        _recheck = true;
    }

    public static OATManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("OATManager").AddComponent<OATManager>();
                Debug.Log("Created OATManager instance");
            }
            return _instance;
        }
    }
}

using Unity.VisualScripting;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public Order order = new Order();
    private int orderSize;
    private float reviewChance = 10;
    private bool leaveReview = false;
    private bool isWaiting = false;
    private const int MaxAverageOrderSize = 4;

    private float satisfaction;
    void Start()
    {
        // Clusterfuck of a number that changes the orderSize in a smooth way, put the formula (1+0.2x^0.7) in a graph to see a visual representation
        satisfaction = Random.Range(90, 100);
        orderSize = Mathf.FloorToInt(Random.Range(1f, 1f + 0.2f * Mathf.Pow(GameManager.instance.current_state.current_day, 0.7f)));
        CreateOrder();
        Debug.Log(order._orderableItems.Count);
    }

    // Update is called once per frame
    void Update()
    {
        handleSatisfaction();
    }

    void CreateOrder()
    {
        for (int i = 0; i < orderSize; i++)
        {
            for (int j = 0; j < Random.Range(1, MaxAverageOrderSize); j++)
            {
                OrderableItem item = new OrderableItem();
                order.addToOrder(new OrderableItem());
                Debug.Log(item.type);
            }
        }
    }

    public void TakeOrder()
    {
        isWaiting = true;
        order.setActive();
        GameManager.instance.orders.Add(order);
    }

    void handleSatisfaction()
    {
        if (isWaiting)
        {
            satisfaction -= 0.5f * Time.deltaTime;
            return;
        }
        if (order.state == Order.State.Finished)
        {
            satisfaction += order.getQuality() * 0.2f;
            leave();
        }
    }

    void leave()
    {

    }
}

using System.IO.Compression;
using Unity.VisualScripting;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public Order order;
    private int orderSize;
    private float reviewChance = 10;
    private bool leaveReview = false;
    private bool isWaiting = false;
    private const int MaxAverageOrderSize = 4;
    public float satisfaction;

    void Start()
    {
        InitializeSatisfaction();
        CalculateOrderSize();
        CreateOrder();
    }

    void Update()
    {
        HandleSatisfaction();
    }

    private void InitializeSatisfaction()
    {
        satisfaction = Random.Range(90, 100);
    }

    private void CalculateOrderSize()
    {
        // Formula (1+0.2x^0.7) creates a smooth progression as days increase
        float dayFactor = GameManager.instance.current_state.current_day;
        float orderSizeMultiplier = 1f + 0.2f * Mathf.Pow(dayFactor, 0.7f);
        orderSize = Mathf.FloorToInt(Random.Range(1f, orderSizeMultiplier));
    }

    void CreateOrder()
    {
        order = new Order();
        for (int i = 0; i < orderSize; i++)
        {
            for (int j = 0; j < Random.Range(1, MaxAverageOrderSize); j++)
            {
                order.addToOrder(new OrderableItem());
            }
        }
    }

    public void TakeOrder()
    {
        isWaiting = true;
        order.setActive();
        float cost = CalculateOrderCost();
        GameManager.instance.current_state.money += cost;
        GameManager.instance.orders.Add(order);
        GameUI.UpdateOrderAmount();
    }

    private float CalculateOrderCost()
    {
        float cost = 0;
        foreach (OrderableItem item in order._orderableItems)
        {
            cost += item.cost;
        }
        return cost;
    }

    void HandleSatisfaction()
    {
        if (isWaiting)
        {
            DecreaseSatisfactionWhileWaiting();
            return;
        }

        if (order.state == Order.State.Finished)
        {
            IncreaseSatisfactionForCompletedOrder();
            Leave();
        }
    }

    private void DecreaseSatisfactionWhileWaiting()
    {
        satisfaction -= 0.5f * Time.deltaTime;
    }

    private void IncreaseSatisfactionForCompletedOrder()
    {
        satisfaction += order.getQuality() * 0.2f;
    }

    void Leave()
    {
        GameManager.instance.customerAmount--;
        GameManager.instance.current_state.customers_served++;
    }
}

using UnityEngine;

public class Customer : MonoBehaviour
{
    public Order order;
    [SerializeField] private float _satisfaction;
    private int _orderSize;
    private float _reviewChance = 10;
    private bool _leaveReview = false;
    private bool _isWaitingOnOrder = false;
    private const int _MaxAverageOrderSize = 4;
    private bool _orderTaken = false;

    void Start()
    {
        float randomX = Random.Range(0.5f, 12.5f);
        float randomY = Random.Range(-5.5f, -6.5f);
        transform.position = new Vector3(randomX, randomY, transform.position.z);

        GameManager.instance.customerAmount++;

        InitializeSatisfaction();
        CalculateOrderSize();
        CreateOrder();
    }

    void Update()
    {
        if (GameManager.instance.passTime)
            HandleSatisfaction();
    }

    private void InitializeSatisfaction()
    {
        _satisfaction = Random.Range(90, 100);
    }

    private void CalculateOrderSize()
    {
        // Formula (1+0.2x^0.7) creates a smooth progression as days increase
        float dayFactor = GameManager.instance.current_state.current_day;
        float orderSizeMultiplier = 1f + 0.2f * Mathf.Pow(dayFactor, 0.7f);
        _orderSize = Mathf.FloorToInt(Random.Range(1f, orderSizeMultiplier));
    }

    void CreateOrder()
    {
        order = new Order();
        for (int i = 0; i < _orderSize; i++)
        {
            for (int j = 0; j < Random.Range(1, _MaxAverageOrderSize); j++)
            {
                order.addToOrder(new OrderableItem(randomiseTypeAndModifier: true));
            }
        }
    }

    public void TakeOrder()
    {
        if (_orderTaken) { return; }

        _orderTaken = true;
        _isWaitingOnOrder = true;

        float randomX = Random.Range(-12.5f, -2.5f);
        float randomY = Random.Range(-2.5f, -6.5f);
        transform.position = new Vector3(randomX, randomY, transform.position.z);

        order.setActive();

        float cost = CalculateOrderCost();

        GameManager.instance.current_state.money += cost;

        GameManager.instance.orders.Add(order);

        OATManager.recheckOrders();
    }

    private float CalculateOrderCost()
    {
        float cost = 0;
        foreach (OrderableItem item in order.orderableItems)
        {
            cost += item.cost;
        }
        return cost;
    }
    void HandleSatisfaction()
    {
        if (_isWaitingOnOrder)
        {
            DecreaseSatisfaction();
            order.checkState();
            if (order.state == Order.State.Finished)
            {
                IncreaseSatisfactionForCompletedOrder();
                Leave();
            }
            return;
        }
        DecreaseSatisfaction(2);
    }

    private void DecreaseSatisfaction(float modifier = 1)
    {
        _satisfaction -= 0.25f * Time.deltaTime * modifier;
    }

    private void IncreaseSatisfactionForCompletedOrder()
    {
        _satisfaction += order.getQuality() * 0.2f;
    }

    void Leave()
    {
        GameManager.instance.customerAmount--;
        GameManager.instance.current_state.customers_served++;
        GameManager.instance.orders.RemoveAll(order => order.state == Order.State.Finished);
        GameUI.RefreshOrderDisplay();
        _leaveReview = Random.Range(0f, 100f) < _reviewChance;
        if (_leaveReview)
        {
            int review = Mathf.CeilToInt(_satisfaction * 0.05f);
            GameManager.instance.current_state.reviewAmount++;
            GameManager.instance.current_state.stars = (GameManager.instance.current_state.stars + review) / GameManager.instance.current_state.reviewAmount;
        }
        Destroy(gameObject);
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TakeOrder();
        }
    }
}

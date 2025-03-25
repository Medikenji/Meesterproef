using System.Collections.Generic;

public class Order
{
    public List<OrderableItem> _orderableItems { get; private set; }
    public State state = State.Imagined;
    public Order()
    {
        _orderableItems = new List<OrderableItem>();
    }

    public void addToOrder(OrderableItem item)
    {
        _orderableItems.Add(item);
    }

    public void setActive()
    {
        state = State.Waiting;
        foreach (OrderableItem item in _orderableItems)
        {
            item.state = State.Waiting;
        }
    }

    public float getQuality()
    {
        float total = 0.0f;
        foreach (OrderableItem item in _orderableItems)
        {
            total += item.quality;
        }
        return total / _orderableItems.Count;
    }

    public enum State
    {
        Imagined,
        Waiting,
        Oat,
        Finished
    }
}

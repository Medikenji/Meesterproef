using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class Order
{
    private List<OrderableItem> _orderableItems;

    public List<OrderableItem> orderableItems
    {
        get
        {
            bool allItemsAreOat = _orderableItems.All(item => item.state == State.Oat);

            if (allItemsAreOat)
            {
                foreach (OrderableItem item in _orderableItems)
                {
                    item.state = State.Finished;
                }
                state = State.Finished;
            }
            return _orderableItems;
        }
        private set
        {
            _orderableItems = value;
        }
    }
    public State state = State.Imagined;
    public Order()
    {
        orderableItems = new List<OrderableItem>();
    }

    public void addToOrder(OrderableItem item)
    {
        orderableItems.Add(item);
    }

    public void setActive()
    {
        state = State.Waiting;
        foreach (OrderableItem item in orderableItems)
        {
            item.state = State.Waiting;
        }
    }

    public float getQuality()
    {
        float total = 0.0f;
        foreach (OrderableItem item in orderableItems)
        {
            total += item.quality;
        }
        return total / orderableItems.Count;
    }

    public enum State
    {
        Imagined,
        Waiting,
        Oat,
        Finished
    }
}

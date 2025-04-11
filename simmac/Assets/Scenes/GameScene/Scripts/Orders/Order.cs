using System.Collections.Generic;
using System.Linq;

public class Order
{
    private List<OrderableItem> _orderableItems;

    public List<OrderableItem> orderableItems
    {
        get
        {
            if (_orderableItems != null && _orderableItems.Count > 0 && _orderableItems.All(item => item.state == State.Oat))
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
    public State state;
    public Order()
    {
        state = State.Imagined;
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

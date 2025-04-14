using System.Collections.Generic;
using System.Linq;

public class Order
{
    public List<OrderableItem> orderableItems { get; private set; }
    public State state;
    public Order()
    {
        state = State.Imagined;
        orderableItems = new List<OrderableItem>();
    }

    public void checkState()
    {
        if (orderableItems != null && orderableItems.Count > 0 && orderableItems.All(item => item.state == State.Oat))
        {
            foreach (OrderableItem item in orderableItems)
            {
                item.state = State.Finished;
                item.quality -= (item.StartTime - GameManager.instance.dayTimeLeft) * 0.5f;
            }
            state = State.Finished;
        }
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

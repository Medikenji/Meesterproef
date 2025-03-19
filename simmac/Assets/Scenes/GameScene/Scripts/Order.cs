using System.Collections.Generic;

public class Order
{
    private List<OrderableItem> _orderableItems;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public enum State
    {
        Imagined,
        Waiting,
        Oat,
        Finished
    }
}

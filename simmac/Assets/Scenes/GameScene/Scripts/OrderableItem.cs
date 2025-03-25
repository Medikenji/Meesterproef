using System;
using UnityEngine;

public class OrderableItem
{
    public float quality = 100;
    public Order.State state = Order.State.Imagined;
    public Type type;

    public OrderableItem()
    {
        Array values = Enum.GetValues(typeof(Type));
        System.Random random = new System.Random();
        type = (Type)values.GetValue(random.Next(values.Length));
    }

    public enum Modifier
    {
        Default,
        Red,
        Green,
        Blue
    }

    public enum Type
    {
        Burger,
        Fries,
        Milkshake,
        Icecream
    }
}

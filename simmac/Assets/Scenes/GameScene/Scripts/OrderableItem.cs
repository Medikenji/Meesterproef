using System;
using UnityEngine;

public class OrderableItem
{
    public float quality = 100;
    public int state = (int)Order.State.Imagined;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public enum Modifier
    {
        Default,
        Red,
        Green,
        Blue
    }
}

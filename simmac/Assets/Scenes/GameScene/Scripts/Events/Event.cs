using System;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class Event : ScriptableObject
{
    /// <summary>
    /// The rarity defines that it should appear every N amount of days where N is the value.
    /// </summary>
    public abstract int rarity { get; }
    public float callTime;
    public bool hasBeenCalled;
    public abstract void CurrentEvent();
}

public class Robbery : Event
{
    public override int rarity { get { return 14; } }

    public override void CurrentEvent()
    {
        Debug.Log("Someone stole from the register");
        GameManager.instance.current_state.money *= 0.9f;
    }

    public static void LoadEvent()
    {
        EventHandler.allEvents.Add(new Robbery());
    }
}

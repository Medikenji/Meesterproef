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

public class TestEvent : Event
{
    public override int rarity { get { return 1; } }

    public override void CurrentEvent()
    {
        Debug.Log("Event0 happend");
    }

    public static void LoadEvent()
    {
        EventHandler.allEvents.Add(new TestEvent());
    }
}

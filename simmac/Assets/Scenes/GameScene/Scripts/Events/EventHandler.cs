using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public static List<Event> allEvents = new List<Event>();
    [SerializeField]
    private List<Event> currentEvents = new List<Event>();
    private int eventsPerDay = 2;

    private const float MinTimeFirstEvent = 40;
    private const float MaxTimeLastEvent = 30;

    void Start()
    {
        allEvents.Clear();
        LoadEvents();
        SortAndPrepareEvents();
    }

    void Update()
    {
        foreach (Event evt in currentEvents)
        {
            if (evt.callTime > GameManager.instance.dayTimeLeft && GameManager.instance.dayTimeLeft != 0 && !evt.hasBeenCalled)
            {
                evt.CurrentEvent();
                evt.hasBeenCalled = true;
            }
        }
    }

    void SortAndPrepareEvents()
    {
        currentEvents.Clear();
        int eventsLoaded = 0;
        allEvents.Sort((event1, event2) => event2.rarity.CompareTo(event1.rarity));
        System.Random randomGenerator = new System.Random();
        foreach (Event evt in allEvents)
        {
            if (eventsLoaded >= eventsPerDay)
            {
                break;
            }
            if (randomGenerator.Next(1, evt.rarity + 1) == evt.rarity)
            {
                evt.callTime = Random.Range(MaxTimeLastEvent, GameManager.dayDurationInSeconds - MinTimeFirstEvent);
                currentEvents.Add(evt);
                eventsLoaded++;
            }
        }
    }

    void LoadEvents()
    {
        TestEvent.LoadEvent();
    }
}

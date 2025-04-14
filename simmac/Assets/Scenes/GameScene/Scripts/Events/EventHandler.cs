using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    // This is called allEvents because Unity reserves the keyword 'event'
    public static List<Event> allEvents = new List<Event>();
    [SerializeField] private List<Event> currentEvents = new List<Event>();
    private int eventsPerDay = 2;

    private const float MinTimeFirstEvent = 40;
    private const float MaxTimeLastEvent = 30;

    void Start()
    {
        InitializeEventSystem();
    }

    void Update()
    {
        CheckAndTriggerEvents();
    }

    private void InitializeEventSystem()
    {
        ClearEventsList();
        LoadEvents();
        SortAndPrepareEvents();
    }

    private void ClearEventsList()
    {
        allEvents.Clear();
    }

    private void CheckAndTriggerEvents()
    {
        foreach (Event evt in currentEvents)
        {
            if (ShouldTriggerEvent(evt))
            {
                TriggerEvent(evt);
            }
        }
    }

    private bool ShouldTriggerEvent(Event evt)
    {
        return evt.callTime > GameManager.instance.dayTimeLeft &&
               GameManager.instance.dayTimeLeft != 0 &&
               !evt.hasBeenCalled;
    }

    private void TriggerEvent(Event evt)
    {
        evt.CurrentEvent();
        evt.hasBeenCalled = true;
    }

    void SortAndPrepareEvents()
    {
        currentEvents.Clear();
        int eventsLoaded = 0;
        SortEventsByRarity();
        SelectRandomEvents(eventsLoaded);
    }

    private void SortEventsByRarity()
    {
        allEvents.Sort((event1, event2) => event2.rarity.CompareTo(event1.rarity));
    }

    private void SelectRandomEvents(int eventsLoaded)
    {
        System.Random randomGenerator = new System.Random();

        foreach (Event evt in allEvents)
        {
            if (eventsLoaded >= eventsPerDay)
            {
                break;
            }

            if (randomGenerator.Next(1, evt.rarity + 1) == evt.rarity)
            {
                AddEventToDay(evt);
                eventsLoaded++;
            }
        }
    }

    private void AddEventToDay(Event evt)
    {
        evt.callTime = Random.Range(MaxTimeLastEvent,
                                     GameManager.DAY_DURATION_SECONDS - MinTimeFirstEvent);
        currentEvents.Add(evt);
    }

    void LoadEvents()
    {
        Robbery.LoadEvent();
    }
}

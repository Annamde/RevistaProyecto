using UnityEngine;
using UnityEngine.Events;

public class EventManager
{
    public UnityEvent CompleteBarraEvent;
    public UnityEvent ActiveChakrasMovementEvent;

    public EventManager()
    {
        if (CompleteBarraEvent == null)
        {
            CompleteBarraEvent = new UnityEvent();
        }
        if (ActiveChakrasMovementEvent == null)
        {
            ActiveChakrasMovementEvent = new UnityEvent();
        }
    }
}

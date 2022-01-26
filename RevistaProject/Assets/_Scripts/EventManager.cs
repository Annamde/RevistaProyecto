using UnityEngine;
using UnityEngine.Events;

public class EventManager
{
    public UnityEvent CompleteBarraEvent;
    public UnityEvent ActiveChakrasMovementEvent;
    public CompleteChakraEvent OnCompleteCharkaEvent;

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
        if (OnCompleteCharkaEvent == null)
        {
            OnCompleteCharkaEvent = new CompleteChakraEvent();
        }
    }
}

public class CompleteChakraEvent : UnityEvent<GameObject>
{
    public GameObject Chakra { get; set; }

    public CompleteChakraEvent()
    {

    }
}

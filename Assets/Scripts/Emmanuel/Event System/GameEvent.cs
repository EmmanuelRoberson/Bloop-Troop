using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

[CreateAssetMenu(menuName = "GameEvents/GameEvent")]
public class GameEvent : ScriptableObject, ISubscribeable
{
    // collection of the gameevent's listeners
    internal List<IListener> listeners = new List<IListener>();
    
    //adds listener to the collection of listeners
    public void AddListener(IListener listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(IListener listener)
    {
        listeners.Remove(listener);
    }

    public void TriggerEvent(params Object[] objects)
    {
        for (var i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventTriggered(objects);
        }
    }

    public void TriggerEvent()
    {
        TriggerEvent(new Object[0]);
    }
}

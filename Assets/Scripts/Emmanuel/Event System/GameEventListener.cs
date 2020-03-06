using UnityEngine;

public class GameEventListener : MonoBehaviour, IListener
{
    [TextArea] public string Notes;

    public GameEvent GameEvent;
    public GameEventResponse Response;

    public GameObject SenderObject;

    public void Subscribe()
    {
        throw new System.NotImplementedException();
    }

    public void Unsubscribe()
    {
        throw new System.NotImplementedException();
    }

    public void OnEventTriggered()
    {
        throw new System.NotImplementedException();
    }

    public void OnEventTriggered(params Object[] objects)
    {
        throw new System.NotImplementedException();
    }
}

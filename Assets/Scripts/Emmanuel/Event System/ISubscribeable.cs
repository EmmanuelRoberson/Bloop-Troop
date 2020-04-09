using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubscribeable
{
    void AddListener(IListener listener);
    void RemoveListener(IListener listener);
    void TriggerEvent(params Object[] objects);
    void TriggerEvent();
}

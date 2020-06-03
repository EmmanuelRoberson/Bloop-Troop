using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{

    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action onCollectFish;
    public event Action onLoseFish;

    public void CollectFishEvent()
    {
        //checks null
        onCollectFish?.Invoke();
    }

    public void LoseFishEvent()
    {
        //checks null
        onLoseFish?.Invoke();
    }

}

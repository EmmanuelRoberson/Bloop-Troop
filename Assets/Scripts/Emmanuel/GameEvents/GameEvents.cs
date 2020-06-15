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
    public event Action<Sprite> onAssignFishSprite;
    public event Action onLoseFish;
    public void CollectFishEvent(Sprite fishSprite)
    {
        //checks null
        onCollectFish?.Invoke();
        onAssignFishSprite?.Invoke(fishSprite);
    }

    public void LoseFishEvent()
    {
        //checks null
        onLoseFish?.Invoke();
    }

}

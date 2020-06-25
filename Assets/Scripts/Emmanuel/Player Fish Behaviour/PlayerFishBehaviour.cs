using System;
using System.Collections;
using System.Collections.Generic;
using Emmanuel;
using UnityEngine;

public class PlayerFishBehaviour : MonoBehaviour
{
    public readonly bool isCollected = true;


    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        /*
        CollectableFishBehaviour otherFish = other.GetComponent<CollectableFishBehaviour>();

        if (otherFish != null)
        {
            GameEvents.current.CollectFishEvent(otherFish.fishSprite);
            Destroy(otherFish.gameObject);
        }
        */
    }
}

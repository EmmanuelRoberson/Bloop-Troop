﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrchinBehaviour : MonoBehaviour
{
    [SerializeField]
    float distanceToActivation;

    [SerializeField]
    bool isDroppable;

    [SerializeField]
    Transform fish;

    bool isFalling = false;

    void fall()
    {
        transform.position = new Vector3(transform.position.x,
                transform.position.y - (Time.fixedDeltaTime / 8), transform.position.z);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDroppable == true)
        {
            if ((transform.position.x - fish.transform.position.x) <= distanceToActivation)
            {
                isFalling = true;
            }

            if (isFalling == true)
            {
                fall();
            }
        }
    }
}
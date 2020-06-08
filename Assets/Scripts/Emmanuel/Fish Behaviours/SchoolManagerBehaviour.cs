﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Emmanuel;
using UnityEngine;
using UnityEngine.UIElements;

public class SchoolManagerBehaviour : MonoBehaviour
{
    public static SchoolManagerBehaviour Instance;
    public List<SchoolPositionBehaviour> SchoolPositions;
    private static Stack<SchoolPositionBehaviour> positionStack = new Stack<SchoolPositionBehaviour>();

    public TestFishBehaviour playerFish;
    
    private void Awake()
    {
        foreach (var position in SchoolPositions)
        {
            positionStack.Push(position);
        }

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //When a fish dies, it will push its position to the top of the stack
    public static void PushPosition(SchoolPositionBehaviour positionToPush)
    {
        positionStack.Push(positionToPush);
    }

    //When a fish needs to be assigned to the next position, use this
    public static SchoolPositionBehaviour PopPosition()
    {
        return positionStack.Pop();
    }
    
}

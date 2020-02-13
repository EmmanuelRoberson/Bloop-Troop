using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Structures;
using UnityEngine;

public static class MovementPhysicsSystem
{
    public delegate void MovePhysicsUpdates(float deltaTime);

    public static MovePhysicsUpdates UpdateDelegate = Instantiate;

    // Empty function used to instantiate delegate
    private static void Instantiate(float deltaTime)
    {
        
    }

    public static void InvokeDelegate()
    {
        UpdateDelegate.BeginInvoke(Time.fixedDeltaTime, null, null);
    }
}

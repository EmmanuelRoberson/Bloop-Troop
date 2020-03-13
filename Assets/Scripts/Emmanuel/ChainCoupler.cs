using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is meant to link to a chain, and to another coupler
public class ChainCoupler<T>
{
    private ChainCoupler<T> couplerLink;
    private ChainNode<T> chainLink;

    public void AddHook(ChainNode<T> hook)
    {
        
    }
}

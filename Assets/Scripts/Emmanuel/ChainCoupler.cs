using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
a
//this class is meant to link the beginning of chain, and to another coupler
public class ChainCoupler<T>
{
    private ChainNode<T> originNode;
    private ChainNode<T> chainLink;

    public ChainCoupler(ChainNode<T> origin)
    {
        originNode = origin;
    }
}

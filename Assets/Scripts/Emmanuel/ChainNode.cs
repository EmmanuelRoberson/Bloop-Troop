using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class ChainNode<T>
{
    //data stored in the node
    public T objectData;
    
    //connected node furthest from beginning of chain
    public ChainNode<T> childNode;
    
    //connected node closest to beginning of chain
    public ChainNode<T> parentNode;
    
    public ChainNode(T newData)
    {
        objectData = newData;
    }
}

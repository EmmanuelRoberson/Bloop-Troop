using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class ChainNode<T>
{
    //used to identify the chain that the node is connected to
    public int branchID;
    
    //data stored in the node
    public T objectData;
    
    public ChainNode<T> childNode;
    public ChainNode<T> parentNode;
}

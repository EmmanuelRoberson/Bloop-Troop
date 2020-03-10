using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public struct GroupNode
{
    public Int16 nodeID;

    public Object objectData;
    
    public List<GroupNode> children;
    public List<GroupNode> parents;
    
}

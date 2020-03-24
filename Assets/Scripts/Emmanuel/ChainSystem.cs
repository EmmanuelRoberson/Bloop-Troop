using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Emmanuel
{
    //class that controls the ChainNode instantiation
    public class ChainSystem<T>
    {
        //object held in the root node of the system 
        private T originNodeObject;
        
        //root node of the web system
        private ChainNode<T> originNode;
        
        //context node for traversing through the system
        private ChainNode<T> contextNode;

        //list of all the nodes childed from the root node
        private List<ChainNode<T>> allNodes;
        
        //constructor
        public ChainSystem(T originObject)
        {
            originNodeObject = originObject;
            originNode = new ChainNode<T>(originObject);
        }

        public void BeginNewChain(T newObject, int chainID)
        {
            
        }
    }
}


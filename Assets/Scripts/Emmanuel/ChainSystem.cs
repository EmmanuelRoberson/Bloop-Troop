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
        private List<ChainCoupler<T>> allCouplers;
        
        //constructor
        public ChainSystem(T originObject)
        {
            allCouplers = new List<ChainCoupler<T>>();
            
            originNodeObject = originObject;
            originNode = new ChainNode<T>(originObject);
            
            ChainCoupler<T> newCoupler = new ChainCoupler<T>(originNode);
            allCouplers.Add(newCoupler);
        }

        public void AddNewChain(T newObject, int chainID)
        {
            ChainCoupler<T> newCoupler = new ChainCoupler<T>(originNode);
        }
    }
}


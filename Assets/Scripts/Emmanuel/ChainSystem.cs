using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Emmanuel
{
    //class that controls the ChainNode instantiation
    public class ChainSystem<T>
    {
        private int numberOfCouplers;

        private int chainLength;
        
        //object held in the root node of the system 
        private T originNodeObject;
        
        //root node of the web system
        private ChainNode<T> originNode;
        
        //context node for traversing through the system
        private ChainNode<T> contextNode;

        //list of all the nodes childed from the root node
        private List<ChainCoupler<T>> allCouplers;
        
        //constructor
        public ChainSystem(T originObject, int chainCouplerLimit, int chainLengthLimit)
        {
            chainLength = chainLengthLimit;
            allCouplers = new List<ChainCoupler<T>>(chainCouplerLimit);
            originNodeObject = originObject;
            originNode = new ChainNode<T>(originObject);
        }

        /// <summary>
        /// adds a new chain to the system
        /// </summary>
        /// <param name="newObject"></param>
        /// <param name="chainID"></param>
        public void AddNewChain(T newObject)
        {
            ChainCoupler<T> newCoupler = new ChainCoupler<T>(chainLength, originNode, newObject);
        }
    }
}


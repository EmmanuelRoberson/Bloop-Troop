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
        private int maxNumberOfCouplers;

        private int chainLength;
        
        //object held in the root node of the system 
        private T originNodeObject;
        
        //root node of the web system
        private ChainNode<T> originNode;
        
        //context node for traversing through the system
        private ChainNode<T> contextNode;

        //list of all the nodes childed from the root node
        private List<ChainCoupler<T>> allCouplers;

        private int longestChainLength;
        
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

        /// <summary>
        /// removes a chain from the end of the list
        /// </summary>
        public void RemoveChain()
        {
            allCouplers[allCouplers.Count - 1] = null;
        }

        public void AddNode(T objectData)
        {
            if (numberOfCouplers < maxNumberOfCouplers)
            {
                numberOfCouplers++;
                AddNewChain(objectData);
                return;
            }
            
            //if all chains are at max length
            if (longestChainLength < chainLength)
            {
                foreach (var coupler in allCouplers)
                {
                    if (coupler.CurrentChainLength < longestChainLength)
                    {
                        coupler.AddNode(objectData);
                        return;
                    }
                }

                allCouplers[0].AddNode(objectData);
                longestChainLength++;
            }
        }

        public void RemoveNode()
        {
            
        }
    }
}


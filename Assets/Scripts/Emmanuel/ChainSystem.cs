using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Emmanuel
{
    public abstract class ChainSystem
    {
        /*
         *        //object held in the root node of the system 
        protected Object rootNodeObject;
        
        //root node of the web system
        protected  ChainNode rootNode;
        
        //context node for traversing through the system
        private ChainNode contextNode;

        //list of all the nodes childed from the root node
        private List<ChainNode> allNodes;
         */
        //constructor
        public ChainSystem(ChainNode root) {}

        public virtual void CompleteJob(){}

        public virtual void ScheduleJob(JobHandle dependentHandle) {}

        /*
        public void TestFunction()
        {
            //NativeArray<ChainNode> result = new NativeArray<ChainNode>(allNodes.Count, Allocator.TempJob);

            TestJob ParallelJob = new TestJob(result);

            JobHandle handle = ParallelJob.Schedule(result.Length, 5);
        }
        */
    }

    /*
    struct TestJob : IJobParallelFor
    {

        private NativeArray<ChainNode> resultNodes;

        public TestJob(NativeArray<ChainNode> resultNodes)
        {
            this.resultNodes = resultNodes;
        }

        public void Execute(int index)
        {
            throw new System.NotImplementedException();
        }
    }
    */
}


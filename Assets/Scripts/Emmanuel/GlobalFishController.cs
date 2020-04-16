using System.Collections.Generic;
using UnityEngine;

namespace Emmanuel
{
    public static class GlobalFishController
    {
        public static ChainSystem<GameObject> fishChainSystem;

        private static Queue<GameObject> gameObjectQueue;

        public static void InstantiateQueue(params GameObject[] initialObjects)
        {
            gameObjectQueue = new Queue<GameObject>(initialObjects);
        }

        public static void AddObjects(params GameObject[] nextObjects)
        {
            foreach (GameObject go in nextObjects)
            {
                gameObjectQueue.Enqueue(go);
            }
        }

        public static GameObject PopNextPosition()
        {
            return gameObjectQueue.Dequeue();
        }
    }
}

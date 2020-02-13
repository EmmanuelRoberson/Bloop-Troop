using System;
using UnityEngine;

namespace Structures
{
    [Serializable]
    public struct MovementPhysicsGroup: IGroupData
    {

        private Vector3 position;
        // position to do calculations on
        public Vector3 Position
        {
            get { return position; }
        }

        // velocity values
        public Vector3 velocity;
        
        // minimum velocity
        public Vector3 minVelocity;
        
        //maximum velocity
        public Vector3 maxVelocity;

        // acceleration values
        public Vector3 accelerationValue;
        
        //minimum acceleration values
        public Vector3 minAcceleration;
        
        //maximum acceleration values
        public Vector3 maxAcceleration;
        
        // jerk values
        public Vector3 jerkValue;

        /// <summary>
        /// custom update function
        /// </summary>
        /// <param name="deltaTime"></param>
        public void Update(float deltaTime)
        {
            
        }

        public Vector3 Velocity => velocity;
    }
}

using System.Collections.Generic;
using UnityEngine;

namespace Flocking.Behaviour_Scripts
{
    [CreateAssetMenu(menuName = "Flock/Behaviour/Cohesion")]
    public class CohesionBehaviour : FlockBehaviour
    {
        public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
            //if no neighbors, return no adjustment
            if (context.Count == 0) return Vector3.zero;
        
            //add all points together and average
            Vector3 cohesionMove = Vector3.zero;
            foreach (var neighbor in context)
            {
                cohesionMove += neighbor.position;
            }

            //average
            cohesionMove /= context.Count;
        
            //create offset from agent position
            cohesionMove -= agent.transform.position;

            return cohesionMove;
        }
    }
}

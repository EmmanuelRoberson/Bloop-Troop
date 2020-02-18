﻿using System.Collections.Generic;
using UnityEngine;

namespace Flocking
{
    public class Flock : MonoBehaviour
    {
        public FlockAgent agentPrefab;
        List<FlockAgent> agents = new List<FlockAgent>();
        public FlockBehaviour behaviour;

        [UnityEngine.Range(10, 500)] public int startingCount = 250;
        [UnityEngine.Range(2,10)] public float agentDensity = 3;

        [UnityEngine.Range(1f, 100f)] public float driveFactor = 10f;
        [UnityEngine.Range(1f, 100f)] public float maxSpeed = 5f;
        [UnityEngine.Range(1f, 10f)] public float neighborRadius = 1.5f;
        [UnityEngine.Range(0f, 1f)] public float avoidanceRadiusMultiplier = 0.5f;

        private float squareMaxSpeed;
        private float squareNeighborRadius;
        private float squareAvoidanceRadius;
        public float SquareAvoidanceRadius { get { return squareAvoidanceRadius;} }

    
        // Start is called before the first frame update
        void Start()
        {
            squareMaxSpeed = maxSpeed * maxSpeed;
            squareNeighborRadius = neighborRadius * neighborRadius;
            squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

            for (int i = 0; i < startingCount; i++)
            {
                FlockAgent newAgent = Instantiate(
                    agentPrefab,
                    Random.insideUnitCircle * startingCount * agentDensity,
                    Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                    transform
                );
                newAgent.name = "Agent " + i;
                newAgent.Initialize(this);
                agents.Add(newAgent);
            }
        }

        // Update is called once per frame
        void Update()
        {
            foreach (FlockAgent agent in agents)
            {
                List<Transform> context = GetNearbyObjects(agent);
                
                Vector2 move = behaviour.CalculateMove(agent, context, this);
                move *= driveFactor;
                if (move.sqrMagnitude > squareMaxSpeed)
                {
                    move = move.normalized * maxSpeed;
                }
                agent.Move(move);
            }
        }

        List<Transform> GetNearbyObjects(FlockAgent agent)
        {
            List<Transform> context = new List<Transform>();
            Collider[] contextColliders = Physics.OverlapSphere(agent.transform.position, neighborRadius);
        
            foreach (var c in contextColliders)
            {
                if (c != agent.AgentCollider)
                {
                    context.Add(c.transform);
                }
            }

            return context;
        }
    }
}

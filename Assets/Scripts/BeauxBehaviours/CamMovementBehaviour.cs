using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BeauxBehaviours
{
    public class CamMovementBehaviour : MonoBehaviour
    {
        public List<Transform> travelCheckpointList;
    
        private Queue<Transform> travelCheckpointQueue;
    
        //starting and ending position for the transitions
        private Vector3 startPosition, endPosition;

        //speed
        public float speed;
        public float speedMultiplier;

        //time at the beginning of a transition
        private float startTime;

        //total distance between checkpoints
        private float journeyLength;

        // Start is called before the first frame update
        void Start()
        {
            startTime = Time.time;
            travelCheckpointQueue = new Queue<Transform>(travelCheckpointList);

            startPosition = transform.position;
            endPosition = travelCheckpointQueue.Dequeue().position;

            journeyLength = Vector3.Distance(startPosition, endPosition);
        }

        // Update is called once per frame
        void Update()
        {
            //Distance covered is the elapsed time * speed
            float distanceCovered = (Time.time - startTime) * (speedMultiplier *speed);

            //Portion of journey complete is the distance covered / total distance
            float portionOfJourney = distanceCovered / journeyLength;
        
            //set the position to the part of the distance covered
            transform.position = Vector3.Lerp(startPosition, endPosition, portionOfJourney);

            if (Vector3.Distance(transform.position, travelCheckpointList[travelCheckpointList.Count - 1].position) <= 3)
            {
                SceneManager.LoadScene("GameWin");
            }
        }
    
        public void UpdateDestination()
        {
            startTime = Time.time;
        
            startPosition = transform.position;
            endPosition = travelCheckpointQueue.Dequeue().position;
        
            journeyLength = Vector3.Distance(startPosition, endPosition);
        
        
        }

        public void SetSpeed(float newSpeed)
        {
            speed = newSpeed;
        }
    }
}

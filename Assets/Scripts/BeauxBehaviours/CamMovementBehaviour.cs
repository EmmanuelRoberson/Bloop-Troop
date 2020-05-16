using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovementBehaviour : MonoBehaviour
{
    [SerializeField]
    MusicAdjusterBehaviour mab;

    [SerializeField]
    float slowValue, normalValue;

    public bool stop, slow, normal = false;

    //[SerializeField]
    //GameObject fish;

    //when the camera reaches this point, it will change speed, direction, or both
    //meant to be assigned in the inspector
    public List<Transform> travelCheckpointList;

    //meant to be used by this script
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
        
        stop = true;
        
        startPosition = transform.position;
        endPosition = travelCheckpointQueue.Dequeue().position;

        journeyLength = Vector3.Distance(startPosition, endPosition);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (normal == true)
        {
            transform.position=new Vector3(transform.position.x+(Time.fixedDeltaTime / normalValue),
                transform.position.y, transform.position.z);
        }

        if (slow == true)
        {
            transform.position=new Vector3(transform.position.x+(Time.fixedDeltaTime / slowValue),
                transform.position.y, transform.position.z);
        }
        */
                
        //mab.ObjectOfRef.floatObj = transform.position.x;
        
        //Distance covered is the elapsed time * speed
        float distanceCovered = (Time.time - startTime) * (speedMultiplier *speed);

        //Portion of journey complete is the distance covered / total distance
        float portionOfJourney = distanceCovered / journeyLength;
        
        //set the position to the part of the distance covered
        transform.position = Vector3.LerpUnclamped(startPosition, endPosition, portionOfJourney);

    }
    
}

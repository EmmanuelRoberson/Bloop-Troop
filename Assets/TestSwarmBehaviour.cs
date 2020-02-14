using System;
using UnityEngine;
using Random = System.Random;

public class TestSwarmBehaviour : MonoBehaviour
{

    public GameObject target;

    public float BeyondDistanceStrength;
    public float WithinDistanceStrength;

    public float StrengthMultiplier;
    
    public float TargetPullDistance;

    private Rigidbody rb;
    private Rigidbody targetRb;
    Random rand;

    private float drag;

    // Start is called before the first frame update
    void Start()
    {
        float drag = 0;
        
        rb = GetComponent<Rigidbody>();

        targetRb = target.GetComponent<Rigidbody>();
        rand = new Random(GetInstanceID());
    }

    // Update is called once per frame
    void Update()
    {
        
        var directionToTarget = target.transform.position - transform.position;
        var distanceFromTarget = Mathf.Abs(Vector3.Distance(target.transform.position, transform.position));

        {
            /*
            if (distanceFromTarget > TargetPullDistance)
            { 
                
                rb.velocity = target.GetComponent<Rigidbody>().velocity + directionToTarget * WithinDistanceStrength;
    
                GetComponent<Rigidbody>().AddForce(Time.fixedDeltaTime * BeyondDistanceStrength * StrengthMultiplier * (directionToTarget * (float)Math.Sin(Time.fixedDeltaTime)));
                
                //rb.velocity = target.GetComponent<Rigidbody>().velocity * BeyondDistanceStrength;
            }
            
            /*
            else
            {
                var rand = new Random(69);
                //rb.velocity = target.GetComponent<Rigidbody>().velocity * WithinDistanceStrength;
                rb.velocity = target.GetComponent<Rigidbody>().velocity +
                              new Vector3(rand.Next(-1, 1), rand.Next(-1, 1), 0) * 10;
            */
        }
        ///////////////////////////////////////////////////////////////////////////
        
        if (distanceFromTarget > TargetPullDistance)
        {
            rb.AddForce(targetRb.velocity + BeyondDistanceStrength * directionToTarget.normalized);
            Debug.Log(targetRb.velocity);
            drag = 0;
        }
        else
        {
            drag += (drag < 1) ? Time.fixedDeltaTime : 0;
        }

        var tempVelo = rb.velocity;
        tempVelo.x *= drag;
        tempVelo.y *= drag;

        rb.velocity = tempVelo;

    }

    private float duringLerpValue;
    

}

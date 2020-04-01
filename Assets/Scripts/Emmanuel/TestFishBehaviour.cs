using System;
using System.Collections;
using System.Collections.Generic;
using Emmanuel;
using UnityEngine;
using UnityEngine.UIElements;

public class TestFishBehaviour : MonoBehaviour
{
    private GameObject parentFish;
    
    private SpringJoint springJoint;
    private bool SpringConnected = false;

    public bool NotInPosition
    {
        get { return (Vector3.Distance(transform.position, fishEnd.transform.position) > 0.005); }
    }
    

    public Vector3 fishStart;
    public GameObject fishEnd;

    public float speed = 1.0f;
    public float journeyLength = 1.0f;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        //startTime = Time.time;
        /*
        
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (SpringConnected == false)
        {
            TestPlayerBehaviour testBeh = other.gameObject.GetComponent<TestPlayerBehaviour>();
            if (testBeh != null)
            {
                parentFish = other.gameObject;
                testBeh.TestPlayerFunction();

                fishEnd = testBeh.nextSchoolPosition;
                ConnectSpring(fishEnd);
            }
        }
    }

    private void ConnectSpring(GameObject go)
    {
        if (!SpringConnected)
        {
            transform.position = go.transform.position;
            
            SpringConnected = true;
            
            springJoint = gameObject.AddComponent<SpringJoint>();
            springJoint.anchor = Vector3.zero;
            springJoint.connectedBody = go.GetComponent<Rigidbody>();
            springJoint.connectedAnchor = go.transform.position;
            springJoint.spring = 200;
            springJoint.damper = 3;
            springJoint.enableCollision = false;
            springJoint.tolerance = 0.025f;
        }
    }
    
    private IEnumerator JoinTheSchoolRoutine()
    {
        yield return null;
    }
}

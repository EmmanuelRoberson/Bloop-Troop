using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class TestSpringBehaviour : MonoBehaviour
{
    private bool connected = false;
    
    private SpringJoint jointData;
    // Start is called before the first frame update
    void Start()
    {
        jointData = GetComponent<SpringJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!connected && other.gameObject.CompareTag("Player"))
        {
            jointData.connectedBody = other.rigidbody;
            connected = true;
        }
    }
}

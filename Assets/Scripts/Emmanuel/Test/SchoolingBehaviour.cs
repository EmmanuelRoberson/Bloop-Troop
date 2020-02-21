using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpringJoint))]
public class SchoolingBehaviour : MonoBehaviour
{
    private SpringJoint jointData;
    private bool isJointed;

    // Start is called before the first frame update
    void Start()
    {
        jointData = GetComponent<SpringJoint>();

        isJointed = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.GetComponent<SchoolingBehaviour>().isJointed)
        {
            jointData.connectedBody = other.rigidbody;
            isJointed = true;
        }
    }
    
    
}

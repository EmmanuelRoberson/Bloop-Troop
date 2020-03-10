using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollectBehaviour : MonoBehaviour
{
    public int NumberOfRows;
    
    private SpringJoint sj;
    public GameObject obj;
    
    // Start is called before the first frame update
    void Start()
    {
        sj = GetComponent<SpringJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        
    }
}

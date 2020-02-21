using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class TestSpringBehaviour : MonoBehaviour
{
    public GameObject connectedBody;
    public Rigidbody connectedRb;
    
    [ReadOnly] public JointDataObject jointData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(transform.position, connectedBody.transform.position);
        
        
        
    }

    public void InitializeComponents()
    {
        connectedRb = connectedBody.GetComponent<Rigidbody>();
    }
    
    
}

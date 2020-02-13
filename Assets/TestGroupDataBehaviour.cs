using System.Collections;
using System.Collections.Generic;
using Structures;
using UnityEngine;

public class TestGroupDataBehaviour : MonoBehaviour
{
    public MovementPhysicsGroup mpg = new MovementPhysicsGroup();
    // Start is called before the first frame update
    void Start()
    {
        MovementPhysicsSystem.UpdateDelegate += mpg.Update;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

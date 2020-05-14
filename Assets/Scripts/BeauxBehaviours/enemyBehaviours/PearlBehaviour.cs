using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearlBehaviour : MonoBehaviour
{

    public Vector3 target;
    public Vector3 owner;

    public bool isParried = false;

    Vector3 spd;
    
    // Start is called before the first frame update
    void Start()
    {
        spd = new Vector3((target.x - owner.x) / 60, (target.y - owner.y) / 60, (target.z - owner.z) / 60);
    }

    // Update is called once per frame
    void Update()
    {
        if (isParried == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 0.1f);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, owner, 0.1f);
        }
    }
}

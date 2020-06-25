using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LungeBehaviour : MonoBehaviour
{
    [SerializeField]
    float spdBack;

    [SerializeField]
    float spdForward;

    [SerializeField]
    float distanceBack;

    [SerializeField]
    float distanceForward;




    // Start is called before the first frame update
    void Start()
    {
        FollowBehaviour followTest;
        followTest = GetComponentInChildren<FollowBehaviour>();
        followTest.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

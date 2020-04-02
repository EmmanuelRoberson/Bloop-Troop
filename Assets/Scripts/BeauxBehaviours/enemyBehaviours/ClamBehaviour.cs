using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClamBehaviour : MonoBehaviour
{
    [SerializeField]
    float distanceToActivation;

    [SerializeField]
    Transform fish;

    float lastShotFired=0;

    void firePearl()
    {
        ;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x - fish.transform.position.x) <= distanceToActivation && fish.transform.position.x < transform.position.x)
        {
            if (lastShotFired <= 0)
            {
                firePearl();
                lastShotFired = 3;
            }
            else
            {
                lastShotFired -= (Time.fixedDeltaTime / 60);
            }
        }
    }
}

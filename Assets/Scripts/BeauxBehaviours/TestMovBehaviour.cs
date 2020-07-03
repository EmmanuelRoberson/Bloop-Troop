using System.Collections;
using System.Collections.Generic;
using BeauxBehaviours;
using UnityEngine;

public class TestMovBehaviour : MonoBehaviour
{
    [SerializeField]
    CamMovementBehaviour cmb;

    void Update()
    {
        /*
        if (cmb.transform.position.x==0)
        {
            if (Input.GetKeyDown("space"))
            {
                cmb.stop = false;
                cmb.normal = true;
            }
        }

        if (cmb.transform.position.x > 8)
        {
            cmb.normal = false;
            cmb.slow = true;
        }
        */
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovBehaviour : MonoBehaviour
{
    [SerializeField]
    CamMovementBehaviour cmb;

    public void SpeedChange(int spdLvl)
    {
        //cmb.stop = false;
        //cmb.slow = false;
        //cmb.normal = false;

        if (spdLvl == 0)
        {
            //stop = true;
        }

        if (spdLvl == 1)
        {
            //slow == true;
        }

        if (spdLvl == 2)
        {
            //normal == true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        CamMovementBehaviour cmb = other.GetComponentInParent<CamMovementBehaviour>();

        //Check trigger for bool, call SpdUp with specific argument for the bool check
    }
}

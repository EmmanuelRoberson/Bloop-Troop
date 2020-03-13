using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovBehaviour : MonoBehaviour
{
    [SerializeField]
    int spdLvl;

    [SerializeField]
    CamMovementBehaviour cmb;

    public void SpeedChange(int spdLvl, Collider Cmb)
    {
        //cmb.stop = false;
        //cmb.slow = false;
        //cmb.normal = false;

        //if (spdLvl == 0)
        //{
        //    Cmb.GetComponentInParent<CamMovementBehaviour>().stop = true;

        //    //stop = true;
        //}

        //if (spdLvl == 1)
        //{
        //    Cmb.GetComponentInParent<CamMovementBehaviour>().slow = true;
        //    //slow == true;
        //}

        //if (spdLvl == 2)
        //{
        //    Cmb.GetComponentInParent<CamMovementBehaviour>().normal = true;
        //    //normal == true;
        //}
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {

        if (spdLvl == 0)
        {
            other.gameObject.GetComponentInParent<CamMovementBehaviour>().stop = true;

            //stop = true;
        }

        if (spdLvl == 1)
        {
            other.gameObject.GetComponentInParent<CamMovementBehaviour>().slow = true;
            //slow == true;
        }

        if (spdLvl == 2)
        {
            other.gameObject.GetComponentInParent<CamMovementBehaviour>().normal = true;
            //normal == true;
        }


        //SpeedChange(spdLvl, other);
        //Check trigger for bool, call SpdUp with specific argument for the bool check
    }

}

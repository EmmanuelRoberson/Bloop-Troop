using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClamBehaviour : MonoBehaviour
{
    [SerializeField]
    float distanceToActivation;

    [SerializeField]
    Transform fish;

    [SerializeField]
    GameObject pearl;

    [SerializeField]
    TestMovBehaviour tmb;

    bool isMoving = false;

    public float lastShotFired=0;

    void firePearl()
    {
        GameObject pearlShot = Instantiate(pearl, this.transform.position, Quaternion.identity);
        //
        if (isMoving == true)
        {
            pearlShot.GetComponent<PearlBehaviour>().target = new Vector3(fish.transform.position.x + (Vector3.Distance(fish.transform.position, this.transform.position)), 
                                                                fish.transform.position.y, fish.transform.position.z);
        }
        else
        {
            pearlShot.GetComponent<PearlBehaviour>().target = new Vector3(fish.transform.position.x, fish.transform.position.y, fish.transform.position.z);
        }
            //

        pearlShot.GetComponent<PearlBehaviour>().owner = this.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (tmb != null)
        {
            isMoving = true;
        }
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
                lastShotFired -= (Time.fixedDeltaTime / 8);
            }
        }
    }
}

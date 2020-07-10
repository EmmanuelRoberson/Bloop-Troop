using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeauxBehaviours;

public class ClamBehaviour : MonoBehaviour
{
    [SerializeField]
    float distanceToActivation;

    [SerializeField]
    Transform fish;

    [SerializeField]
    GameObject pearl;

    [SerializeField]
    CamMovementBehaviour tmb;

    [SerializeField]
    float timeBetweenShots;

    [SerializeField]
    float spdOfPearls;

    bool isMoving = false;

    public float lastShotFired=0;

    void firePearl()
    {
        GameObject pearlShot = Instantiate(pearl, this.transform.position, Quaternion.identity);
        //
        if (isMoving == true)
        {
            Vector3 holder = new Vector3(fish.transform.position.x - transform.position.x, fish.transform.position.y - transform.position.y * tmb.speed, fish.transform.position.z);
            holder.Normalize();
            pearlShot.GetComponent<PearlBehaviour>().target = holder;
        }
        else
        {

            Vector3 holder = new Vector3(fish.transform.position.x - transform.position.x, fish.transform.position.y - transform.position.y, fish.transform.position.z);
            holder.Normalize();
            pearlShot.GetComponent<PearlBehaviour>().target = holder;
        }
            //

        pearlShot.GetComponent<PearlBehaviour>().owner = this.transform.position;

        pearlShot.GetComponent<PearlBehaviour>().spd = spdOfPearls;

        //6/25/2020
        pearlShot.GetComponent<PearlBehaviour>().creator = GetComponent<Collider>();
        //
    }

    // Start is called before the first frame update
    void Start()
    {
        if (tmb != null)
        {
            isMoving = true;
        }

        if (spdOfPearls == null)
            spdOfPearls = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x - fish.transform.position.x) <= distanceToActivation && fish.transform.position.x < transform.position.x)
        {
            if (lastShotFired <= 0)
            {
                firePearl();
                lastShotFired = timeBetweenShots;
            }
            else
            {
                lastShotFired -= (Time.fixedDeltaTime / 8);
            }
        }
    }
}

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
    float lifeOfPearls;

    bool isMoving = false;

    public float lastShotFired=0;

    void firePearl()
    {
        GameObject pearlShot = Instantiate(pearl, this.transform.position, Quaternion.identity);
        //
        if (isMoving == true)
        {
            pearlShot.GetComponent<PearlBehaviour>().target = new Vector3(fish.transform.position.x + 
                                                                (Vector3.Distance(fish.transform.position, this.transform.position) * tmb.speed), 
                                                                    fish.transform.position.y, fish.transform.position.z);
        }
        else
        {
            pearlShot.GetComponent<PearlBehaviour>().target = new Vector3(fish.transform.position.x, fish.transform.position.y, fish.transform.position.z);
        }
            //

        pearlShot.GetComponent<PearlBehaviour>().owner = this.transform.position;

        pearlShot.GetComponent<PearlBehaviour>().lifeTime = lifeOfPearls;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (tmb != null)
        {
            isMoving = true;
        }

        if (lifeOfPearls == null)
            lifeOfPearls = 25;
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

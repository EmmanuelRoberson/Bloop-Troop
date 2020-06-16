using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothBehaviour : MonoBehaviour
{

    [SerializeField]
    Transform fish;

    [SerializeField]
    GameObject tooth;

    [SerializeField]
    int numberOfTeeth;

    [SerializeField]
    int numberOfSets;

    [SerializeField]
    float timeBetweenShots;

    [SerializeField]
    float timeBetweenSets;

    [SerializeField]
    float spdOfTeeth;

    public float lastShotFired = 0;
    public int currentTeeth = 0;
    public int currentSets = 0;

    void FireTooth()
    {
        GameObject toothShot = Instantiate(tooth, this.transform.position, Quaternion.identity);

        Vector3 holder = new Vector3(fish.transform.position.x - transform.position.x, fish.transform.position.y - transform.position.y, fish.transform.position.z);
        holder.Normalize();
        toothShot.GetComponent<PearlBehaviour>().target = holder;

        toothShot.GetComponent<PearlBehaviour>().owner = this.transform.position;

        toothShot.GetComponent<PearlBehaviour>().spd = spdOfTeeth;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (spdOfTeeth == null)
            spdOfTeeth = 6;
    }

    // Update is called once per frame
    void Update()
    {
            if (lastShotFired <= 0)
            {
                FireTooth();
                currentTeeth++;
                if (currentTeeth == numberOfTeeth)
                {
                    lastShotFired = timeBetweenSets;
                    currentTeeth = 0;
                    currentSets++;
                }
                else
                {
                    lastShotFired = timeBetweenShots;
                }

                if (currentSets == numberOfSets)
                {
                    //kill this script
                }
            }
            else
            {
                lastShotFired -= (Time.fixedDeltaTime / 8);
            }
    }
}

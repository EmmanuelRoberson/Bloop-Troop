using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearlBehaviour : MonoBehaviour
{

    public Vector3 target;
    public Vector3 owner;

    public bool isParried = false;

    bool targetChange = false;

    Vector3 spd;
    

    public float lifeTime;

    

    void spdChange()
    {
        spd = new Vector3((owner.x - transform.position.x) / 60, (owner.y - transform.position.y) / 60, (owner.z - transform.position.z) / 60);
    }

    void OnTriggerExit (Collider other)
    {
        GetComponent<LifeBehaviour>().hasEscaped = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        spd = new Vector3((target.x - owner.x) / 60, (target.y - owner.y) / 60, (target.z - owner.z) / 60);
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += spd * Time.fixedDeltaTime * 6;

        if (isParried && targetChange == false)
        {
            spdChange();
            targetChange = true;
        }

        lifeTime -= Time.fixedDeltaTime;

        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}

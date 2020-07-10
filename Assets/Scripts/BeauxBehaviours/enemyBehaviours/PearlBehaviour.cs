using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearlBehaviour : MonoBehaviour
{

    public Vector3 target;
    public Vector3 owner;

    public bool isParried = false;

    bool targetHasChanged = false;

    [SerializeField]
    float lifeTime;

    //avoids accidental trigger breaks
    public Collider creator;

    [SerializeField]
    public float spd;
    

    void targetChange()
    {
        Vector3 holder = new Vector3(owner.x - transform.position.x, owner.y - transform.position.y, owner.z - transform.position.z);
        holder.Normalize();
        target = holder;
    }

    void OnTriggerExit (Collider other)
    {
        //creator check 6/25/2020
        if (other == creator)
            GetComponent<LifeBehaviour>().hasEscaped = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (spd == null)
        {
            spd = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += target * spd * Time.fixedDeltaTime;

        if (isParried && targetHasChanged == false)
        {
            targetChange();
            targetHasChanged = true;
        }

        lifeTime -= Time.fixedDeltaTime;

        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}

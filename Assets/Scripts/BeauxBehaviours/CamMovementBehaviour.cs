using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovementBehaviour : MonoBehaviour
{
    [SerializeField]
    MusicAdjusterBehaviour mab;

    public bool stop, slow, normal = false;

    //[SerializeField]
    //GameObject fish;

    // Start is called before the first frame update
    void Start()
    {
        stop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (normal == true)
        {
            transform.position=new Vector3(transform.position.x+(Time.fixedDeltaTime / 10),
                transform.position.y, transform.position.z);
        }

        if (slow == true)
        {
            transform.position=new Vector3(transform.position.x+(Time.fixedDeltaTime / 15),
                transform.position.y, transform.position.z);
        }



        mab.ObjectOfRef.floatObj = transform.position.x;
    }
    
}

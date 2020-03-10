using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovementBehaviour : MonoBehaviour
{
    [SerializeField]
    MusicAdjusterBehaviour mab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + (Time.fixedDeltaTime/10), transform.position.y, 
            transform.position.z);

        mab.ObjectOfRef.floatObj = transform.position.x;
    }
}

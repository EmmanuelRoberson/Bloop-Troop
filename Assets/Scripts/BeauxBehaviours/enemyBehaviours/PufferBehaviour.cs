using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PufferBehaviour : MonoBehaviour
{
    [SerializeField]
    float distanceToActivation;

    [SerializeField]
    bool isSwimming;

    [SerializeField]
    Transform fish;

    [SerializeField]
    bool isPuffed;

    [SerializeField]
    float swimSpd;
    //default is 0.45

    [SerializeField]
    float puffIncrease = 0.5f;
    //default is 0.5

    void puff()
    {
        transform.localScale = new Vector3((transform.localScale.x + puffIncrease), 
                                (transform.localScale.y + puffIncrease), (puffIncrease));
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isSwimming == true)
        {
            transform.position = new Vector3(transform.position.x - (Time.fixedDeltaTime * swimSpd),
                transform.position.y, transform.position.z);
        }

        if (isPuffed == false)
        {
            if ((transform.position.x - fish.transform.position.x) <= distanceToActivation )
            {
                isPuffed = true;
                puff();
            }
        }
    }
}

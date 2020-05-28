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

    void puff()
    {
        transform.localScale = new Vector3((transform.localScale.x + 0.5f),
                (transform.localScale.y + 0.5f), (transform.localScale.z));
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
            transform.position = new Vector3(transform.position.x - (Time.fixedDeltaTime / 45),
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

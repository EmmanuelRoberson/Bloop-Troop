using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishLifeBehaviour : MonoBehaviour
{
    [SerializeField]
    int healthVal = 1;

    bool isDead = false;

    public float iFrames = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy") && iFrames <= 0)
        {
            healthVal -= 1;
            iFrames = 6;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(healthVal<=0)
        {
            isDead = true;
        }

        if (isDead == true)
        {
            GetComponentInParent<TestMovementBehaviour>().enabled = false;
        }
        else if(iFrames>0)
        {
            iFrames -= (Time.fixedDeltaTime);
        }
    }
}

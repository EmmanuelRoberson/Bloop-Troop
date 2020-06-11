﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBehaviour : MonoBehaviour
{
    public float iFrames=0;

    [SerializeField]
    float iFrameVal;

    [SerializeField]
    bool isFish;

    [SerializeField]
    bool isEnemy;

    [SerializeField]
    bool isParryable;

    [SerializeField]
    int healthVal;

    public bool hasEscaped = false;

    private void TakeDamage()
    {
        healthVal -= 1;
        iFrames = iFrameVal;
    }

    private void OnTriggerStay(Collider other)
    {
        if (isFish && iFrames <= 0)
        {
            if (other.gameObject.CompareTag("Enemy") && iFrames <= 0 || other.gameObject.CompareTag("Parryable") && iFrames <= 0 && GetComponent<FishLifeBehaviour>().isParrying == false)
            {
                TakeDamage();
                transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z + 0.4f, transform.rotation.w);

                if (healthVal <= 0)
                {
                    GetComponent<FishLifeBehaviour>().isDead = true;
                }
            }
        }

        if (isEnemy && iFrames <= 0 && other.GetComponent<LifeBehaviour>().hasEscaped == true)
        {
            
                TakeDamage();
            
        }

        if (isParryable && hasEscaped == true)
        {
            FishLifeBehaviour flb = other.GetComponent<FishLifeBehaviour>();
            if (flb != null && flb.isParrying == true)
            {
                GetComponent<PearlBehaviour>().isParried = true;
            }
            else
            {
                TakeDamage();
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        if (healthVal == null)
            healthVal = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (iFrames > 0)
        {
            if (iFrames <= iFrameVal - 2 && isFish && healthVal > 0)
            {
                transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, transform.rotation.w);
            }

            iFrames -= (Time.fixedDeltaTime);
        }

        if (isEnemy || isParryable)
        {
            if (healthVal <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
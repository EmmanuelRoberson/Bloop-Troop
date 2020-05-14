using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Emmanuel;

public class FishLifeBehaviour : MonoBehaviour
{
    [SerializeField]
    int healthVal = 1;

    bool isDead = false;

    public float iFrameVal = 6;

    float iFrames = 0;

    public float countdown = 0;

    bool isPlayer=false;

    /// ///////
    bool isDetached=false;
    ////////////
    ///

    bool isParrying = false;
    float parryTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        isPlayer = GetComponent<TestFishBehaviour>().isPlayer;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy") && iFrames <= 0 || other.gameObject.CompareTag("Parryable") && iFrames <= 0 && isParrying == false)
        {
            healthVal -= 1;
            iFrames = iFrameVal;
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z + 0.4f, transform.rotation.w);
        }

        if (isParrying ==true && other.gameObject.CompareTag("Parryable"))
        {
            other.GetComponentInParent<PearlBehaviour>().isParried = true;
        }

        if (healthVal <= 0)
        {
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 3, transform.rotation.w);
            isDead = true;
            if (isPlayer == true)
                countdown = 3;
            //////////
            else if (isDetached == false)
            {
                TestFishBehaviour tfbehav = GetComponentInParent<TestFishBehaviour>();
                tfbehav.DetachFishFromSchool(tfbehav);
                isDetached = true;
            }
            //////////
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space") && isParrying == false && isDead == false)
        {
            isParrying = true;
            parryTime = 3.0f;
        }

        if (isDead == true)
        {
            if (GetComponentInParent<TestMovementBehaviour>() != null)
            {
                GetComponentInParent<TestMovementBehaviour>().enabled = false;
            }

            if (isPlayer == true)
            {
                countdown -= (Time.fixedDeltaTime);

                if (countdown <= 0.0f)
                {
                    SceneManager.LoadScene("GameOver");
                }
            }

        }
        else if(iFrames>0)
        {
            if (iFrames <= iFrameVal-2)
            {
                transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, transform.rotation.w);
            }

            iFrames -= (Time.fixedDeltaTime);
        }

        if (parryTime > 0)
        {
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 270, transform.rotation.w);
            parryTime -= (Time.fixedDeltaTime);

            if (parryTime <= 0)
            {
                transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, transform.rotation.w);
            }
        }
        else
        {
            isParrying = false;

        }
    }
}

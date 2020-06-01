using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Emmanuel;

public class FishLifeBehaviour : MonoBehaviour
{
    public bool isDead = false;

    public float countdown = 3;
    //how long after death til game over

    bool hasMovement = false;
    // checks to see if there is a movement script to turn off upon death

    bool isPlayer=false;

    /// ///////
    bool isDetached=false;
    // checks to see if it must be detached or not
    ///

    public bool isParrying = false;

    // Start is called before the first frame update
    void Start()
    {
        isPlayer = GetComponent<TestFishBehaviour>().isPlayer;

        if (GetComponent<TestMovementBehaviour>() != null)
        {
            hasMovement = true;
        }
    }
    

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space") && isParrying == false && isDead == false )
        {
            isParrying = true;
            this.GetComponent<ParryBehaviour>().enabled = true;
        }

        if (isDead == true)
        {
            if (GetComponent<TestMovementBehaviour>() != null)
            {
                GetComponent<TestMovementBehaviour>().enabled = false;
            }

            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 3, transform.rotation.w);

            if (isPlayer != true && isDetached == false)
            {
                TestFishBehaviour tfbehav = GetComponentInParent<TestFishBehaviour>();
                tfbehav.DetachFishFromSchool(tfbehav);
                isDetached = true;
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
        
    }
}

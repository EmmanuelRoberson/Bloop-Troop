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

    /// ///////
    bool isDetached=false;
    // checks to see if it must be detached or not
    ///
    private bool isPlayer;
    
    public bool isParrying = false;

    private SchoolFishBehaviour fishBehaviour;
    //script attached to a fish in the school
    
    private PlayerFishBehaviour playerBehaviour;
    //script attached to the player

    private TestMovementBehaviour playerMovement;
    //player movement behaviour

    private ParryBehaviour parryBehaviour;
    //parry behaviour

    // Start is called before the first frame update
    void Start()
    {
        fishBehaviour = GetComponent<SchoolFishBehaviour>();
        //behaviour script attached to the fish
        
        playerBehaviour = GetComponent<PlayerFishBehaviour>();
        //behaviour script attached to the player

        playerMovement = GetComponent<TestMovementBehaviour>();
        //movement script attached to the player

        parryBehaviour = GetComponent<ParryBehaviour>();
        
        if (playerMovement != null)
        {
            hasMovement = true;
        }

        isPlayer = playerBehaviour != null;
    }
    

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space") && isParrying == false && isDead == false )
        {
            isParrying = true; 
            parryBehaviour.enabled = true;
        }

        if (isDead == true)
        {
            if (playerMovement != null)
            {
                playerBehaviour.enabled = false;
            }

            GameEvents.current.LoseFishEvent(fishBehaviour);
            
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 3, transform.rotation.w);

            if (isPlayer && isDetached == false)
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

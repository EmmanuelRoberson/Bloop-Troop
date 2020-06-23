using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseConditionBehaviour : MonoBehaviour
{

    [SerializeField]
    float countdown = 3;

    [SerializeField]
    GameObject blockLeft;

    [SerializeField]
    GameObject blockRight;
    
    // curtain closing process has activated
    bool curtainClose = false;

    // the blocks are now moving
    bool blocksEnabled = false;

    // the curtains have closed
    public bool hasCollided = false;

    void activateCurtains()
    {
        blockLeft.GetComponent<Renderer>().enabled = true;
        blockRight.GetComponent<Renderer>().enabled = true;

        curtainClose = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= (Time.fixedDeltaTime);

        if (countdown <= 0.0f && curtainClose == false)
        {
            activateCurtains();

            //SceneManager.LoadScene("GameOver");
        }

        if (curtainClose == true && blocksEnabled == false)
        {
            blockLeft.GetComponent<CurtainBehaviour>().enabled = true;
            blockRight.GetComponent<CurtainBehaviour>().enabled = true;
            blocksEnabled = true;
        }

        if (hasCollided == true)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}

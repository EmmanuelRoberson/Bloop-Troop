using System.Collections;

using BeauxBehaviours;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class LoseConditionBehaviour : MonoBehaviour
{

    [SerializeField]
    float countdown = 3;

    [SerializeField]
    GameObject blockLeft;

    [SerializeField]
    GameObject blockRight;
    
    // curtain closing process has activated
    public bool curtainClose = false;

    // the curtains have closed
    public bool hasCollided = false;

    [FormerlySerializedAs("cameraCheckpointBehaviour")] public CamMovementBehaviour camMovement;

    void activateCurtains()
    {
        blockLeft.GetComponent<MeshRenderer>().enabled = true;
        blockRight.GetComponent<MeshRenderer>().enabled = true;

        blockLeft.GetComponent<CurtainBehaviour>().CloseCurtains();
        blockRight.GetComponent<CurtainBehaviour>().CloseCurtains();

        camMovement.enabled = false;
        
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
            curtainClose = true;

        }

        if (hasCollided == true)
        {
            StartCoroutine(CountdownToNextSceneCoroutine());
            hasCollided = false;
        }
    }

    IEnumerator CountdownToNextSceneCoroutine()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("GameOver");

    }
}

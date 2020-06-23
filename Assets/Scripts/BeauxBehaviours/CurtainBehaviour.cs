using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainBehaviour : MonoBehaviour
{
    [SerializeField]
    bool isLeft;

    [SerializeField]
    bool isRight;

    [SerializeField]
    float curtainSpd;
    
    [SerializeField]
    LoseConditionBehaviour lose;

    bool hasStopped = false;

    private void OnTriggerEnter(Collider other)
    {
        lose.hasCollided = true;
        hasStopped = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("SampleCoroutine");
    }

    private IEnumerator SampleCoroutine()
    {
        while (hasStopped == false)
        {
            //code goes here

            if (isLeft)
            {
                transform.position = new Vector3(transform.position.x + (curtainSpd * Time.fixedDeltaTime), transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x + (curtainSpd * Time.fixedDeltaTime * -1), transform.position.y, transform.position.z);
            }

            yield return 0;
        }
   
    }

}

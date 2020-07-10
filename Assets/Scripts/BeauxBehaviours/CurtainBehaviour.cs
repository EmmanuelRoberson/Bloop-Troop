using System.Collections;

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

    public bool hasStopped = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CurtainBehaviour>() != null)
        {
            lose.hasCollided = true;
            hasStopped = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseCurtains()
    {
        StartCoroutine(CurtainCloseCoroutine());
    }
    
    
    private IEnumerator CurtainCloseCoroutine()
    {
        while (hasStopped == false)
        {
            //code goes here
            if (isLeft)
            {
                transform.position += new Vector3(curtainSpd * Time.fixedDeltaTime, 0, 0);
                
                //transform.position = new Vector3(transform.position.x + (curtainSpd * Time.fixedDeltaTime), transform.localPosition.y, transform.localPosition.z);
            }
            else
            {
                transform.position += new Vector3(-curtainSpd * Time.fixedDeltaTime, 0, 0);
                
                //transform.position = new Vector3(transform.position.x + (curtainSpd * Time.fixedDeltaTime * -1), transform.localPosition.y, transform.localPosition.z);
            }

            yield return 0;
        }
    }

}

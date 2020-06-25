using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalagtiteBehaviour : MonoBehaviour
{

    //MAKE THIS ISPARRYABLE AS A TAG

    [SerializeField]
    bool isMoving = false;

    [SerializeField]
    float fallSpd;

    void fall()
    {
        transform.position = new Vector3(transform.position.x,
                transform.position.y - (Time.fixedDeltaTime * fallSpd), transform.position.z);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (isMoving == false)
        {
            isMoving = true;
        }

        if (other.gameObject.CompareTag("Enemy") && isMoving == true)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == true)
        {
            fall();
        }
    }
}

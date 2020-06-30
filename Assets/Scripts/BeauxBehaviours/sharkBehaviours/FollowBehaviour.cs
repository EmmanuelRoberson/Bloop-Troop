using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBehaviour : MonoBehaviour
{

    [SerializeField]
    Transform camera;

    [SerializeField]
    Transform target;

    [SerializeField]
    Vector3 targetVisual;

    [SerializeField]
    float spd;

    [SerializeField]
    float camMax;

    [SerializeField]
    float camMin;

    [SerializeField]
    float fishMax;

    [SerializeField]
    float fishMin;

    float timerForToothTest = 0;

    // Start is called before the first frame update
    void Start()
    {
        targetVisual = target.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (/*transform.position.y >= (fishMax + target.position.y) && transform.position.y <= (fishMin + target.position.y)*/ Mathf.Abs(target.position.y - transform.position.y) >= 1f)
        //{
        //    if(transform.position.y >= (fishMax + target.position.y) && transform.position.y < camMax + camera.position.y)
        //    {
        //        Vector3 holder = new Vector3(0, target.position.y - transform.position.y, 0);
        //        holder.Normalize();
        //        transform.position += holder * spd * Time.fixedDeltaTime;
        //    }

        //    if (transform.position.y <= (fishMin + target.position.y) || transform.position.y > camMin + camera.position.y)
        //    {
        //        Vector3 holder = new Vector3(0, target.position.y - transform.position.y, 0);
        //        holder.Normalize();
        //        transform.position += holder * spd * Time.fixedDeltaTime;
        //    }
        //}
        targetVisual = target.position;

        timerForToothTest += Time.fixedDeltaTime;

        if (timerForToothTest <= 10)
        {
            ToothBehaviour toothTest;
            toothTest = GetComponentInChildren<ToothBehaviour>();
            toothTest.enabled = true;
        }
    }
}

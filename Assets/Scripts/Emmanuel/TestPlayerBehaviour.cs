using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerBehaviour : MonoBehaviour
{
    public GameObject nextSchoolPosition;
    // Start is called before the first frame update
    void Start()
    {
        System.Random rand1 = new System.Random((int)Time.time);
        Vector3 offset = new Vector3(rand1.Next(-3, -1), rand1.Next(-3, -1), 0);

        nextSchoolPosition.transform.position += offset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TestPlayerFunction()
    {
        Debug.Log("Testing Collision");
    }
}

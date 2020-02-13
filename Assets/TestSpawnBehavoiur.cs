using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawnBehavoiur : MonoBehaviour
{
    public GameObject test;

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 5)
        {
            var obj = Instantiate(test);
            obj.AddComponent<TestGroupDataBehaviour>();
            timer = 0f;
        }

        timer += Time.deltaTime;
    }
}

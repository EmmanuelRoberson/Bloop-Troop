using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkScootBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartScoot();
        }
    }

    public IEnumerator ScootUpCoroutine()
    {
        var time = 0f;
        while (time <= 2)
        {
            transform.localPosition += new Vector3(5, 0, 0) * Time.deltaTime;
            time += Time.deltaTime;
            
            yield return 0;
        }


        
    }

    public void StartScoot()
    {
        StartCoroutine(ScootUpCoroutine());
    }
    
}

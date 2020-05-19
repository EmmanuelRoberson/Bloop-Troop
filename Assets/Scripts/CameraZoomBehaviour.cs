using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomBehaviour : MonoBehaviour
{

    public float a, b;


    private float tDistance;
    private float w;
    public float currentValue;
    
    // Start is called before the first frame update
    void Start()
    {
        tDistance = Mathf.Abs(a - b);
        w = currentValue / tDistance;
    }

    // Update is called once per frame
    void Update()
    {
        currentValue = (a * w) + (b * (1 - w));
    }
}

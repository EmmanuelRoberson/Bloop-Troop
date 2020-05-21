using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraZoomBehaviour : MonoBehaviour
{
    private float fieldOfView;
    private float bezierPointA;
    
    //total time for it to come to rest
    public float ZoomTime;

    //the peak of the zoom in one go
    public float zoomPeakOffset;

    //how far the resting point is from where it started
    public float endingRestOffset;

    private float elapsedTime;
    
    
    // Start is called before the first frame update
    void Start()
    {
        fieldOfView = GetComponent<Camera>().fieldOfView;
        GameEvents.current.onCollectFish += DoZoomEffect;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    //used as a function of time, returns a float based on a quadratic bezier curve
    // t should should be from 0 - 1
    float QuadBezier(float t, float A, float B, float C)
    {
        float s = 1 - t;
        float s2 = Mathf.Pow(s, 2);
        float t2 = Mathf.Pow(t, 2);
        
        return (s2 * A) + (2 * s * t * B) + (t2 * C);
    }

    public void DoZoomEffect()
    {
        bezierPointA = fieldOfView;
        elapsedTime = 0;
        StartCoroutine(ZoomEffectCoroutine(Time.deltaTime));
    }

    IEnumerator ZoomEffectCoroutine(float deltaTime)
    {
        while (elapsedTime <= ZoomTime)
        {
            var t = elapsedTime / ZoomTime;
            fieldOfView = QuadBezier(t, bezierPointA, bezierPointA + zoomPeakOffset, bezierPointA + endingRestOffset);
            elapsedTime += deltaTime;
            Debug.Log(fieldOfView);
            GetComponent<Camera>().fieldOfView = fieldOfView;
            
            yield return 0;
        }
    }
}

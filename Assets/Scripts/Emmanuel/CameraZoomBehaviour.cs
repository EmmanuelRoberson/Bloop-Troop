using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraZoomBehaviour : MonoBehaviour
{

    public int maxZoomCount;
    private int currentZoomCount;
    private float fieldOfView;
    private float bezierPointA;
    
    //total time for it to come to rest
    public float zoomInTime;
    
    //the peak of the zoom in in one go
    public float zoomInMaxValue;
    public float zoomInRestValue;
        
    
    public float zoomOutTime;

    //the peak of the zoom in one go
    public float zoomOutMaxValue;



    //how far the resting point is from where it started
    public float zoomOutRestValue;


    
    private float elapsedTime;

    private Camera camera;
    
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        fieldOfView = camera.fieldOfView;
        GameEvents.current.onCollectFish += DoZoomOutEffect;
        GameEvents.current.onLoseFish += DoZoomInEffect;
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

    public void DoZoomOutEffect()
    {
        if (currentZoomCount < maxZoomCount)
        {
            bezierPointA = fieldOfView;
            elapsedTime = 0;
            StartCoroutine(ZoomOutEffectCoroutine(Time.deltaTime));
            currentZoomCount++;
        }
    }

    public void DoZoomInEffect()
    {
        bezierPointA = fieldOfView;
        elapsedTime = 0;
        StartCoroutine(ZoomInEffectCoroutine(Time.deltaTime));
        currentZoomCount--;
    }

    private IEnumerator ZoomOutEffectCoroutine(float deltaTime)
    {
        while (elapsedTime <= zoomOutTime)
        {
            float t = elapsedTime / zoomOutTime;
            fieldOfView = QuadBezier(t, bezierPointA, bezierPointA + zoomOutMaxValue, bezierPointA + zoomOutRestValue);
            elapsedTime += deltaTime;
            camera.fieldOfView = fieldOfView;
            
            yield return 0;
        }
    }

    private IEnumerator ZoomInEffectCoroutine(float deltaTime)
    {
        while (elapsedTime <= zoomInTime)
        {
            float t = elapsedTime / zoomInTime;
            fieldOfView = QuadBezier(t, bezierPointA, bezierPointA + zoomInMaxValue, bezierPointA + zoomInRestValue);
            elapsedTime += deltaTime;
            camera.fieldOfView = fieldOfView;

            yield return 0;
        }
    }
}

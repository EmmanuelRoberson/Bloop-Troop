using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerBehviour : MonoBehaviour
{
    public Transform[] views;
    public float transitionSpeed;
    private Transform currentView;
    private int viewsIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        viewsIndex = 0;
        currentView = views[0];
        StartCoroutine(TransitionToViewRoutine());
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
       
    }

    private IEnumerator TransitionToViewRoutine()
    {
        Vector3 initialPosition = transform.position;
        while(Mathf.Abs(Vector3.Distance(transform.position, currentView.position)) > 1f)
        {
            transform.position =
                Vector3.Lerp(transform.position, currentView.position, Time.fixedDeltaTime * transitionSpeed);

            var currentViewRotation = currentView.transform.rotation;
        
            Vector3 currentAngle = new Vector3(
                Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentViewRotation.eulerAngles.x, Time.fixedDeltaTime *transitionSpeed),
                Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentViewRotation.eulerAngles.y, Time.fixedDeltaTime *transitionSpeed),
                Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentViewRotation.eulerAngles.z, Time.fixedDeltaTime *transitionSpeed));


            transform.eulerAngles = currentAngle;
        
            yield return 0;   
        }

        viewsIndex++;
        if (viewsIndex <= views.Length)
        {
            initialPosition = currentView.position;
            currentView = views[viewsIndex];
            
        }
    }
}

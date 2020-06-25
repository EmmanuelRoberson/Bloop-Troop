using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerBehviour : MonoBehaviour
{
    public Transform[] views;
    public float transitionSpeed;
    private Transform currentView;
    
    // Start is called before the first frame update
    void Start()
    {
        currentView = views[0];
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position =
            Vector3.Lerp(transform.position, currentView.position, Time.fixedDeltaTime * transitionSpeed);

        var currentViewRotation = currentView.transform.rotation;
        
        Vector3 currentAngle = new Vector3(
            Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentViewRotation.eulerAngles.x, Time.deltaTime *transitionSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentViewRotation.eulerAngles.y, Time.deltaTime *transitionSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentViewRotation.eulerAngles.z, Time.deltaTime *transitionSpeed));


        transform.eulerAngles = currentAngle;

    }

    private IEnumerator TransitionToViewRoutine(Transform viewTransform)
    {
        while(Mathf.Abs(Vector3.Distance(transform.position, currentView.position)) > 0.1f)
        {
            transform.position =
                Vector3.Lerp(transform.position, currentView.position, Time.fixedDeltaTime * transitionSpeed);

            var currentViewRotation = currentView.transform.rotation;
        
            Vector3 currentAngle = new Vector3(
                Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentViewRotation.eulerAngles.x, Time.deltaTime *transitionSpeed),
                Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentViewRotation.eulerAngles.y, Time.deltaTime *transitionSpeed),
                Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentViewRotation.eulerAngles.z, Time.deltaTime *transitionSpeed));


            transform.eulerAngles = currentAngle;
        
            yield return 0;   
        }
       
    }
}

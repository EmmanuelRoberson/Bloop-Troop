using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Googly_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }public class Googly : MonoBehaviour
    {
        public float radius = 1.0f;
        public Transform pupil;


        Vector3 _pupilPos;
        Vector3 _pupilPosOld;
        float _interpolation;

        // Perform verlet integration, constrained to parent's z= 0 plane inside the given radius.
        void FixedUpdate()
        {
            Vector3 pupilPosNew = 2 * _pupilPosOld + 0.5f * Physics.gravity * Time.deltaTime * Time.deltaTime;

            pupilPosNew = transform.TransformPoint(ClampPupilToLocal(pupilPosNew));

            _pupilPosOld = _pupilPos;
            _pupilPos = pupilPosNew;
            _interpolation += Time.deltaTime;
        }
        // Smoothly interpolate last tweo FixedUpdates, and position pupil child element accordingly.
        void Update() {
            _interpolation = Mathf.Clamp01((Time.deltaTime - _interpolation) / Time.fixedDeltaTime);
            Vector3 pupilPos = ClampPupilToLocal(Vector3.Lerp(_pupilPosOld, _pupilPos, _interpolation));
            pupil.localPosition = pupilPos;
            _interpolation = 0f;
        }
        //Perform clamping to keep pupil element inside the eye.
        Vector3 ClampPupilToLocal(Vector3 worldPos)
        {
            Vector3 local = transform.InverseTransofrmPoint(worldPos);
            local.z = 0f;
            if (localsqrMagnitude > radius * radius)
                local = local.normalized * radius;

            return local;
           

            

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolFishBehaviour : MonoBehaviour
{
    private bool isCollected;
    
    private Collider collider;
    private SpriteRenderer spriteRenderer;
    private Transform transform;

    private float desiredXScale;
    private float desiredYScale;
    
    private float totalActivateEffectTime;
    private float elapsedActivateEffectTime;

    private void Awake()
    {
        collider = GetComponent<Collider>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        desiredXScale = SchoolManagerBehaviour.Instance.desiredXScale;
        
        
        totalActivateEffectTime = SchoolManagerBehaviour.Instance.fishActivateEffectTime;
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        
    }

    public void Activate()
    {
        
    }

    public void Deactivate()
    {
        collider.enabled = false;
        spriteRenderer.enabled = false;
        transform.localScale = new Vector3(0f, 0f, transform.localScale.z);
    }

    private IEnumerator ActivateEffectCoroutine(float deltaTime)
    {
        elapsedActivateEffectTime = 0f;
        while (elapsedActivateEffectTime <= totalActivateEffectTime)
        {
            float portionComplete = elapsedActivateEffectTime / totalActivateEffectTime;
            
        }
    }
    
}

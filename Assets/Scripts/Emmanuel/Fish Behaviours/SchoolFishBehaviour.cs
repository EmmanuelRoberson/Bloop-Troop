using System;
using System.Collections;
using System.Collections.Generic;
using Emmanuel;
using TMPro;
using UnityEditorInternal;
using UnityEngine;

public class SchoolFishBehaviour : MonoBehaviour
{
    public bool isCollected;
    
    private Collider collider;
    private SpriteRenderer spriteRenderer;

    private float desiredXScale;
    private float desiredYScale;
    
    public float totalActivateEffectTime;
    private float elapsedActivateEffectTime;

    private void Awake()
    {
        collider = GetComponent<Collider>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
       
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        /*
        if (other.CompareTag("Enemy") || other.CompareTag("Parryable"))
        {
            collider.enabled = false;
            GameEvents.current.LoseFishEvent(this);
            return;
        }
        
        CollectableFishBehaviour collectableFish = other.GetComponent<CollectableFishBehaviour>();
        if (collectableFish != null)
        {
            GameEvents.current.CollectFishEvent(collectableFish.fishSprite);
            
            Destroy(collectableFish.gameObject);
        }
        */
    }
    
    public void Activate(Sprite newSprite)
    {
        isCollected = true;
        SetFishSprite(newSprite);
        spriteRenderer.enabled = true;
        collider.enabled= true;
        StartCoroutine(ActivateEffectCoroutine(Time.fixedDeltaTime));
    }

    public void Deactivate()
    {
        isCollected = false;
        collider.enabled = false;
        spriteRenderer.enabled = false;
        
        transform.localScale = new Vector3(0f,0f,transform.localScale.z);
    }

    public void DeactivateFishRoutine()
    {
        StartCoroutine(DeactivateEffectCoroutine(Time.fixedDeltaTime));
    }
    
    public void SetFishSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }
    
    public void SetScales(float x, float y)
    {
        desiredXScale = x;
        desiredYScale = y;
    }
    
    private IEnumerator ActivateEffectCoroutine(float deltaTime)
    {
        transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, transform.rotation.w);
        
        elapsedActivateEffectTime = 0f;

        while (elapsedActivateEffectTime <= totalActivateEffectTime && Math.Abs(transform.localScale.x - desiredXScale) > 0.01)
        {
            float portionComplete = elapsedActivateEffectTime / (totalActivateEffectTime * 0.7f);

            float x = CustomMath.CubicBezier(portionComplete, 0f, 2, 4, desiredXScale);
            float y = CustomMath.CubicBezier(portionComplete, 0f, 2, 4, desiredYScale);

            elapsedActivateEffectTime += deltaTime;
            
            transform.localScale = new Vector3(x, y, transform.localScale.z);

            if (elapsedActivateEffectTime >= totalActivateEffectTime)
            {
                collider.enabled = true;
            }
            
            yield return 0;
        }
    }

    private IEnumerator DeactivateEffectCoroutine(float deltaTime)
    {
        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(0.01f);
        Time.timeScale = 1;
        
        elapsedActivateEffectTime = 0;

        transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 90, transform.rotation.w);
        
        while (elapsedActivateEffectTime <= totalActivateEffectTime && Math.Abs(transform.localScale.x) > 0.01)
        {
            float portionComplete = elapsedActivateEffectTime / totalActivateEffectTime;

            float x = CustomMath.CubicBezier(portionComplete, desiredXScale, 4, 2, 0f);
            float y = CustomMath.CubicBezier(portionComplete, desiredYScale, 4, 2, 0f);

            elapsedActivateEffectTime += deltaTime;
            
            transform.localScale = new Vector3(x, y, transform.localScale.z);

            yield return 0;
        }
        
        Deactivate();
        transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, transform.rotation.w);

        yield return 0;

    }
    
}

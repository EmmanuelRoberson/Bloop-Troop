using System;
using System.Collections;
using System.Collections.Generic;
using Emmanuel;
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
        CollectableFishBehaviour collectableFish = other.GetComponent<CollectableFishBehaviour>();
        if (collectableFish != null)
        {
            GameEvents.current.CollectFishEvent(collectableFish.fishSprite);
            
            Destroy(collectableFish.gameObject);
        }
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
        elapsedActivateEffectTime = 0f;
        
        while (elapsedActivateEffectTime <= totalActivateEffectTime && Math.Abs(transform.localScale.x - desiredXScale) > 0.01)
        {
            float portionComplete = elapsedActivateEffectTime / totalActivateEffectTime;
            //float x = CustomMath.QuadBezier(portionComplete, 0f, 10, desiredXScale);
            //float y = CustomMath.QuadBezier(portionComplete, 0f, 10, desiredYScale);

            float x = CustomMath.CubicBezier(portionComplete, 0f, 1, 1, desiredXScale);
            float y = CustomMath.CubicBezier(portionComplete, 0f, 1, 1, desiredYScale);

            elapsedActivateEffectTime += deltaTime;
            
            transform.localScale = new Vector3(x, y, transform.localScale.z);

            if (elapsedActivateEffectTime >= totalActivateEffectTime)
            {
                collider.enabled = true;
            }
                

            yield return 0;
        }
    }
    
}

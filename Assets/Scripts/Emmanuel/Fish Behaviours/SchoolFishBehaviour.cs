using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolFishBehaviour : MonoBehaviour
{
    private bool isCollected;
    
    private Collider collider;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        collider = GetComponent<Collider>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
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
        
    }
}

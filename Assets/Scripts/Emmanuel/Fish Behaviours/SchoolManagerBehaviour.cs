using System;
using System.Collections.Generic;
using Emmanuel;
using UnityEngine;

using Random = UnityEngine.Random;

public class SchoolManagerBehaviour : MonoBehaviour
{
    public GameObject fishBasePrefab;
    
    public SchoolManagerBehaviour Instance;
    public List<SchoolFishBehaviour> fishSchool;
    private Stack<SchoolFishBehaviour> fishStack = new Stack<SchoolFishBehaviour>();

    public List<Sprite> fishSprites;
    private Sprite currentFishSprite;
    
    public PlayerFishBehaviour playerFish;

    public float fishActivateEffectTime;

    public float desiredXScale;
    public float desiredYScale;

    private void Awake()
    {
        Instance = this;
        GameEvents.current.onAssignFishSprite += ActivateFish;
    }

    private void Start()
    {
        foreach (var fish in fishSchool)
        {
            fish.SetScales(desiredXScale, desiredYScale);
            fish.totalActivateEffectTime = fishActivateEffectTime;
            fish.Deactivate();
            
            PushFishToActivate(fish);
        }

        GameEvents.current.onDeactivateFish += DeactivateFish;
        GameEvents.current.onDeactivateFish += PushFishToActivate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //When a fish dies, it will push its position to the top of the stack
    public void PushFishToActivate(SchoolFishBehaviour schoolFish)
    {
        fishStack.Push(schoolFish);
    }

    //When a fish needs to be assigned to the next position, use this
    public void ActivateFish(Sprite fishSprite)
    {
        fishStack.Pop().Activate(fishSprite);
    }

    public void DeactivateFish(SchoolFishBehaviour schoolFishBehaviour)
    {
        schoolFishBehaviour.DeactivateFishRoutine();
    }
    
}

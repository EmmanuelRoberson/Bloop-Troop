using System.Collections;
using System.Collections.Generic;
using Emmanuel;
using UnityEngine;

public class PlayerFishBehaviour : TestFishBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        isPlayer = true;
        playerFishAttached = 0;
        state = FISH_STATE.COLLECTED;
        assignmentDirection = POSITION_ASSIGN_DIRECTION.UP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}

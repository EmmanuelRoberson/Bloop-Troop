using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PositionAssignmentBehaviour : MonoBehaviour
{
    public GameObject MainObject;
    public List<List<GameObject>> Objects;
    public FishPositionList fishPosList;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    [ExecuteInEditMode]
    void SetPositions()
    {
        int fishIndex = 0;
        foreach (var fishPos in fishPosList.fishOffsets)
        {
            fishPosList.fishOffsets[fishIndex]
                = fishPos - MainObject.transform.position;

            fishIndex++;
        }
    }
    
    //the first 6 are preset, the others are assigned to the preset fish
    // the fish could have a mode at which they assign direction that controls where the fish snap to(ect up left, up, down)
    //can be kept in track with the chain system
    
}

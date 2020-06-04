using System.Collections;
using System.Collections.Generic;
using Emmanuel;
using UnityEngine;

public class SchoolPositionBehaviour : MonoBehaviour
{
    private TestFishBehaviour assignedFish;

    public List<SchoolPositionBehaviour> neighbors;

    private List<SchoolPositionBehaviour> occupiedNeighbors;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddAssignedFish(TestFishBehaviour addedFish)
    {
        assignedFish = addedFish;
        SetOccupiedStatus();
    }

    public void RemoveAssignedFish()
    {
        assignedFish = null;
        SetUnoccupiedStatus();
    }

    public void SetOccupiedStatus()
    {
        foreach (var neighbor in neighbors)
        {
            neighbor.occupiedNeighbors.Add(this);
        }
    }

    public void SetUnoccupiedStatus()
    {
        foreach (var neighbor in neighbors)
        {
            neighbor.occupiedNeighbors.Remove(this);
        }
    }
}

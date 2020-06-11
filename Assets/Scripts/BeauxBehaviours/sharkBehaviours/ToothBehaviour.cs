using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothBehaviour : MonoBehaviour
{

    [SerializeField]
    GameObject tooth;

    [SerializeField]
    int numberOfTeeth;

    [SerializeField]
    float timeBetweenShots;

    [SerializeField]
    float timeBetweenSets;

    [SerializeField]
    float lifeOfPearls;

    void FireTooth()
    {
        GameObject toothShot = Instantiate(tooth, this.transform.position, Quaternion.identity);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

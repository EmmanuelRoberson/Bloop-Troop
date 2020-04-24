using System;
using Emmanuel;
using UnityEngine;
using Random = UnityEngine.Random;

public class TestSpawnBehavoiur : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public float spawnChancePercent;

    private Collider collider;
    
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObject(Vector3 spawnPosition)
    {
        var obj = Instantiate(ObjectToSpawn, spawnPosition, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            var calculatedChance = Random.Range(0, 100);
            if (calculatedChance <= spawnChancePercent)
            {
                SpawnObject(other.transform.position);
            }
        }
    }
}

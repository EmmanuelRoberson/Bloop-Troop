using System;
using System.Collections.Generic;
using Emmanuel;
using UnityEngine;
using Random = UnityEngine.Random;

public class TestSpawnBehavoiur : MonoBehaviour
{
    public List<GameObject> ObjectsToSpawn;
    public float spawnChancePercent;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    private void SpawnObject(Vector3 spawnPosition)
    {
        int index = (int)UnityEngine.Random.Range(0, ObjectsToSpawn.Count - 1);
        GameObject obj = Instantiate(ObjectsToSpawn[index], spawnPosition, Quaternion.identity);
        obj.GetComponent<CollectableFishBehaviour>().fishSprite = obj.GetComponentInChildren<SpriteRenderer>().sprite;
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

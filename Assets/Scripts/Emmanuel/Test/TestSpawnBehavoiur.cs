
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TestSpawnBehavoiur : MonoBehaviour
{
    public List<GameObject> ObjectsToSpawn;
    public float spawnChancePercent;

    private int schoolSize = 17;
    private int currentSize = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onCollectFish += IncrementSize;
        GameEvents.current.onLoseFish += DecrementSize;
    }

    private void SpawnObject(Vector3 spawnPosition)
    {
        if (currentSize < schoolSize)
        {
            int index = (int) UnityEngine.Random.Range(0, ObjectsToSpawn.Count - 1);
            GameObject obj = Instantiate(ObjectsToSpawn[index], spawnPosition, Quaternion.identity);
            obj.GetComponent<CollectableFishBehaviour>().fishSprite =
                obj.GetComponentInChildren<SpriteRenderer>().sprite;
        }
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

    public void IncrementSize()
    {
        currentSize++;
    }

    public void DecrementSize()
    {
        currentSize--;
    }
    
}

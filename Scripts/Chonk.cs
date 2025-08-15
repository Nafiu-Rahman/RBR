using UnityEngine;
using System.Collections.Generic;

public class Chonk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] float appleSpawnChance = .3f;
    [SerializeField] float coinSpawnChance = .5f;
    [SerializeField] float coinSeperationLength = 2f;
    [SerializeField] float[] lanes = { -2.5f, 0f, 2.5f };

    List<int> availableLanes = new List<int> { 0, 1, 2 };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnFance();
        SpawnApple();
        SpawnCoin();
    }

    void SpawnFance()
    {

        int fancesToSpawn = Random.Range(0,lanes.Length);
        for (int i = 0; i < fancesToSpawn; i++)
        {
            if (availableLanes.Count == 0) break;

            int laneIndex = SelectLane();

            Vector3 spawnPosition = new Vector3(lanes[laneIndex], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }

    void SpawnCoin()
    {
        if (Random.value > coinSpawnChance) return;
        if (availableLanes.Count <= 0) return;
        int laneIndex = SelectLane();
        int coinsToSpawn = Random.Range(0, 5);
        float topOfChonkPpos = transform.position.z + (coinSeperationLength * 2f);
            

        for (int i = 0; i < coinsToSpawn; i++)
        {
            float spawnPositionZ = topOfChonkPpos + (coinSeperationLength * i);
            Vector3 spawnPosition = new Vector3(lanes[laneIndex], transform.position.y, spawnPositionZ);
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity, this.transform);
        }  
    }

    void SpawnApple()
    {
            if (Random.value > appleSpawnChance) return;
            if (availableLanes.Count <= 0) return;
            int laneIndex = SelectLane();

            Vector3 spawnPosition = new Vector3(lanes[laneIndex], transform.position.y, transform.position.z);
            Instantiate(applePrefab, spawnPosition, Quaternion.identity, this.transform);    
    }

    int SelectLane()
    {
        int randomIndex = Random.Range(0, availableLanes.Count);
        int laneIndex = availableLanes[randomIndex];
        availableLanes.RemoveAt(randomIndex);
        return laneIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

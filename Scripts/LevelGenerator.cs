using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] CameraController cameraController;
    [SerializeField] GameObject[] Chonkybois;
    [SerializeField] int startingConkAmount = 12;
    [SerializeField] int checkpointChonkInterval = 8;
    [SerializeField] Transform ChonkyParent;
    [SerializeField] float chonkLength = 10f;
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float minMoveSpeed = 2f;
    [SerializeField] float maxMoveSpeed = 15f;
    [SerializeField] GameObject checkpointChonkPrefab;

    //GameObject[] chonks = new GameObject[12];
    List<GameObject> chonks = new List<GameObject>();
    int chonkSpawned = 0;


    private void Start()
    {
        SpawnChonkyBois();
    }

    private void Update()
    {
        MoveChonks();         
    }

    public void ChangeMoveSpeed(float speedAmount)
    {
        moveSpeed += speedAmount;
        if (moveSpeed < minMoveSpeed)
        {
            moveSpeed = minMoveSpeed;
        }
        if (moveSpeed > maxMoveSpeed)
        {
            moveSpeed = maxMoveSpeed;
        }

        Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, Physics.gravity.z - speedAmount);
        cameraController.ChangeCameraFOV(speedAmount);
    }
    
    void SpawnChonkyBois()
    {
        for (int i = 0; i < startingConkAmount; i++)
        {
            float spawnPositionZ = CalculateSpawnPositionZ();
            
            GameObject chonkToSpawn;
            Vector3 chonkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
            if (chonkSpawned % checkpointChonkInterval == 0 && chonkSpawned != 0)
            {
                chonkToSpawn = checkpointChonkPrefab;
                //chonkSpawnPos.y += 2f; // Adjust height for checkpoint chonk
            }
            else
            {
                chonkToSpawn = Chonkybois[Random.Range(0, Chonkybois.Length)];
            }

            GameObject newChonk = Instantiate(chonkToSpawn, chonkSpawnPos, Quaternion.identity, ChonkyParent);

            chonks.Add(newChonk);
            chonkSpawned++;
        }
    }

    float CalculateSpawnPositionZ()
    {
        //amra ekta ekta kore slab spawn korbo
        float spawnPositionZ;
        //chonks.Count
        if (chonks.Count == 0)
        {
            spawnPositionZ = transform.position.z;
        }

        else//shamner kono chonk er position
        {
            //spawnPositionZ = transform.position.z + (i * chonkLength);//chonk size er length poriman baralei hocche
            spawnPositionZ = chonks[chonks.Count - 1].transform.position.z + chonkLength;
        }
        return spawnPositionZ;
    }

    void MoveChonks()
    {
        //for (int i = 0; i < chonks.Length; i++)
        for (int i = 0; i < chonks.Count; i++)
        {
            GameObject chonk = chonks[i];
            //chonk er position update korbo
            chonk.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            //jodi chonk er position camera er pichone jay oke destroy kore dibo
            if (chonk.transform.position.z <= Camera.main.transform.position.z - chonkLength)
            {
                chonks.Remove(chonk);
                Destroy(chonk);
                SpawnChonkyBois();
            }
        }
    }
}

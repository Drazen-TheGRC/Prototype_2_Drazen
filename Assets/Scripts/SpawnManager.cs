using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private float spawnRangeX = 17.0f;
    private float spawnRangeZ = 20.0f;

    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f;

    public float sideSpawnMinZ;
    public float sideSpawnMaxZ;
    public float sideSpawnX;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SpawnRandomAnimal();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnRightAnimal();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            SpawnLeftAnimal();
        }

    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnRangeZ);
        Instantiate(animalPrefabs[animalIndex], spawnPosition, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnLeftAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPosition = new Vector3(-sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        Vector3 rotationWhenSpawndOnTheLeft = new Vector3(0, 90, 0);
        Instantiate(animalPrefabs[animalIndex], spawnPosition, Quaternion.Euler(rotationWhenSpawndOnTheLeft));
    }

    void SpawnRightAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPosition = new Vector3(sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        Vector3 rotationWhenSpawndOnTheRight = new Vector3(0, -90, 0);
        Instantiate(animalPrefabs[animalIndex], spawnPosition, Quaternion.Euler(rotationWhenSpawndOnTheRight));
    }
}

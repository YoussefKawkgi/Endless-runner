using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundManager : MonoBehaviour
{
    public GameObject[] groundPrefabs;  // Array of different ground prefabs
    public GameObject[] obstaclePrefabs; // Array of different obstacle prefabs
    public Transform spawnPoint;        // Spawn point for the ground
    public float groundLength = 10f;    // Length of each ground tile
    public float obstacleSpawnChance = 0.5f; // 50% chance of spawning an obstacle

    private float nextGroundSpawnX = 0f; // Position to spawn the next ground tile

    void Start()
    {
        SpawnInitialGround();
    }

    void Update()
    {
        if (ShouldSpawnNewGround())
        {
            SpawnGroundWithObstacle();
        }
    }

    void SpawnInitialGround()
    {
        // Spawn enough ground to cover the initial game space
        for (int i = 0; i < 5; i++)
        {
            SpawnGroundWithObstacle();
        }
    }

    bool ShouldSpawnNewGround()
    {
        // Check if we need to spawn a new ground tile based on the player's position
        return Camera.main.transform.position.x >= nextGroundSpawnX - (groundLength * 2);
    }

void SpawnGroundWithObstacle()
{
    int randomGroundIndex = Random.Range(0, groundPrefabs.Length);
    GameObject ground = Instantiate(groundPrefabs[randomGroundIndex], new Vector3(nextGroundSpawnX, spawnPoint.position.y, 0), Quaternion.identity);

    float groundWidth = ground.GetComponent<SpriteRenderer>().bounds.size.x;
    nextGroundSpawnX += groundWidth;

    // Randomly spawn an obstacle on top of the ground tile
    if (Random.value < obstacleSpawnChance)
    {
        int randomObstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        float obstacleXOffset = Random.Range(-groundWidth / 2f, groundWidth / 2f);
        Vector3 obstaclePosition = new Vector3(ground.transform.position.x + obstacleXOffset, ground.transform.position.y + 1, 0);
        
        GameObject obstacle = Instantiate(obstaclePrefabs[randomObstacleIndex], obstaclePosition, Quaternion.identity);
        
        // Parent the obstacle to the ground so it moves with the ground
        obstacle.transform.parent = ground.transform;
    }
}
}
using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject colorSwitcherPrefab;
    public float distanceBetweenObjects = 5f;
    public int initialObjectCount = 10;

    private float lastYPosition = 0f;
    private List<GameObject> spawnedObjects = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < initialObjectCount; i++)
        {
            SpawnNextSet();
        }
    }

    private void Update()
    {
        // Check if we need to spawn more objects
        if (Camera.main.transform.position.y + Camera.main.orthographicSize > lastYPosition - distanceBetweenObjects)
        {
            SpawnNextSet();
        }

        // Remove objects that are far below the camera
        CleanUpObjects();
    }

    private void SpawnNextSet()
    {
        // Spawn an obstacle
        GameObject obstacle = SpawnObstacle();
        spawnedObjects.Add(obstacle);

        // Spawn a color switcher after the obstacle
        GameObject colorSwitcher = SpawnColorSwitcher();
        spawnedObjects.Add(colorSwitcher);

         
    }

    private GameObject SpawnObstacle()
    {
        GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        Vector3 spawnPosition = new Vector3(0, lastYPosition + distanceBetweenObjects, 0);
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        lastYPosition = spawnPosition.y;
        return obstacle;
    }

    private GameObject SpawnColorSwitcher()
    {
        Vector3 spawnPosition = new Vector3(0, lastYPosition + distanceBetweenObjects, 0);
        GameObject colorSwitcher = Instantiate(colorSwitcherPrefab, spawnPosition, Quaternion.identity);
        lastYPosition = spawnPosition.y;
        return colorSwitcher;
    }

   

    private void CleanUpObjects()
    {
        float cameraBottomY = Camera.main.transform.position.y - Camera.main.orthographicSize;
        while (spawnedObjects.Count > 0 && spawnedObjects[0].transform.position.y < cameraBottomY - 10f)
        {
            GameObject objectToRemove = spawnedObjects[0];
            spawnedObjects.RemoveAt(0);
            Destroy(objectToRemove);
        }
    }
}
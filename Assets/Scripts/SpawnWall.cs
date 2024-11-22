using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWall : MonoBehaviour
{
    public GameObject wallPrefab; 
    public float minY = -7f;      
    public float maxY = -3f;       
    public float spawnInterval = 3f; 

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(WallSpawn), 0, spawnInterval);
    }

    void WallSpawn()
    {
        float randomY = Random.Range(minY, maxY);

        Vector3 spawnPosition = new Vector3(15, randomY, 0); 
        GameObject newWall = Instantiate(wallPrefab, spawnPosition, Quaternion.identity);
        Destroy(newWall, 15f);
    }
}

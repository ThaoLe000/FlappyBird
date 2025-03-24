using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWall : MonoBehaviour
{
    [SerializeField] private float spawnX ;
    [SerializeField] private float minY;      
    [SerializeField] private float maxY;       
    [SerializeField] private float spawnInterval;
    [SerializeField] private float spawnItem;
    private ObjectPool objectPool;
    [SerializeField] private GameObject[] itemPrefabs;
    

    private void Awake()
    {
        objectPool = GetComponent<ObjectPool>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(WallSpawn), 0f, spawnInterval);
        InvokeRepeating(nameof(ItemSpawn), 5f, spawnItem);
    }

    void WallSpawn()
    {
        float randomY = Random.Range(minY, maxY);
        Vector2 spawnPosition = new Vector2(spawnX, randomY);
        objectPool.GetWallPrefab(spawnPosition);
    }
    void ItemSpawn()
    {
        int randomIndex = Random.Range(0, itemPrefabs.Length);
        Instantiate(itemPrefabs[randomIndex], transform.position, Quaternion.identity );
    }
}

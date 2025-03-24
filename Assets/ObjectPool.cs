using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefabWall;
    [SerializeField] private int poolSize;
     private Queue<GameObject> pool = new Queue<GameObject>();

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefabWall);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }
    public GameObject GetWallPrefab (Vector2 position)
    {
        GameObject obj;
        if( pool.Count > 0)
        {
            obj = pool.Dequeue();
        }
        else
        {
            obj = Instantiate(prefabWall);
        }
        obj.transform.position = position;
        obj.SetActive(true);
        return obj;
    }

    public void DestroyWall(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}

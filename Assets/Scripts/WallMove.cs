using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f; 
    private ObjectPool pool;
    private void Awake()
    {
        pool = FindObjectOfType<ObjectPool>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(-1 * Time.deltaTime * moveSpeed, 0));

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DestroyWall")
        {
            pool.DestroyWall(gameObject);
        }
    }
}

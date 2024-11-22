using UnityEngine;
using System.Collections;

public class BackGroundMove : MonoBehaviour
{

    public float moveSpeed;
    public float moveRange;

    private Vector3 oldPosition;
    private GameObject obj;
    // Use this for initialization
    void Start()
    {
        obj = gameObject;
        oldPosition = obj.transform.position;
        moveSpeed = 5;
        moveRange = 32;
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, 0, 0));

        if (Vector3.Distance(oldPosition, obj.transform.position) > moveRange)
        {
            obj.transform.position = oldPosition;
        }
    }
}
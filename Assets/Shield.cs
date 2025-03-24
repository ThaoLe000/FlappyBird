using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private BirdSkill birdSkill;
    [SerializeField] private float amplitude; //Bien do dao dong
    [SerializeField] private float frequency; // Tan so dao dong
    [SerializeField] private float speed;
    [SerializeField] private AudioClip shieldSound;
    private Vector3 startPosition;
    private Vector3 velocity;

    private void Start()
    {
        birdSkill = GameObject.FindFirstObjectByType<BirdSkill>();
        startPosition = transform.position;
        velocity = new Vector3(speed, 0, 0);
    }

    private void Update()
    {
        transform.position += -velocity * Time.deltaTime;
        float newY = startPosition.y + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(shieldSound);
            birdSkill.ActiveShield(0);
            Destroy(gameObject);
        }
    }

}

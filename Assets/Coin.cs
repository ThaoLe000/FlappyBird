using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coin;
    [SerializeField] private float amplitude; //Bien do dao dong
    [SerializeField] private float frequency; // Tan so dao dong
    [SerializeField] private float speed;
    [SerializeField] private AudioClip coinSound;
    private Vector3 startPosition;
    private Vector3 velocity;

    private void Start()
    {
        startPosition = transform.position;
        velocity = new Vector3(speed, 0,0);
    }

    private void Update()
    {
        transform.position += -velocity * Time.deltaTime;
        float newY = startPosition.y + Mathf.Sin(Time.time *frequency) * amplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    public void AddCoin(int value)
    {
        int money = PlayerPrefs.GetInt("Money", 0);
        money += value;
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.Save();
        Debug.Log("Them tien "+ money);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(coinSound);
            AddCoin(coin);
            Destroy(gameObject);
        }
    }
}

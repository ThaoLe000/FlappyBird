using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] private float flyPower;
    [SerializeField] private AudioClip flyClip;
    [SerializeField] AudioClip deathClip;
    [SerializeField] AudioClip gameOverClip;
    [SerializeField] AudioClip pointClip;
    private AudioSource audioSource;
    private Rigidbody2D rb;
    private Animator animator;

    GameObject obj;
    GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        animator = obj.GetComponent<Animator>();
        animator.SetFloat("flyPower", 0);
        animator.SetBool("isDead", false);
        rb = obj.GetComponent<Rigidbody2D>();

        if(gameController == null)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!gameController.GetComponent<GameController>().isEndGame)
            {
                SoundManager.instance.PlaySound(flyClip);
                rb.velocity = Vector2.up * flyPower;
            }
        }
        animator.SetFloat("flyPower", obj.GetComponent<Rigidbody2D>().velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "BlockWall") return;
        if (collision.gameObject.tag == "Wall")
        {
            EndGame();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Point")
        {
            gameController.GetComponent<GameController>().GetPoint();
            SoundManager.instance.PlaySound(pointClip);
        }
    }

    void EndGame()
    {   
        animator.SetBool("isDead", true);
        SoundManager.instance.PlaySound(deathClip);
        Invoke(nameof(PlayGameOverSound), 1f);
        gameController.GetComponent<GameController>().EndGame();
    }

    void PlayGameOverSound()
    {
        SoundManager.instance.PlaySound(gameOverClip);
    }
}

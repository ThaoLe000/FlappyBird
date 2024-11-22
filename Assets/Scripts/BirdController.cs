using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float flyPower = 5f;
    public AudioClip flyClip;
    public AudioClip deathClip;
    public AudioClip gameOverClip;
    private AudioSource audioSource;

    private Animator animator;

    GameObject obj;
    GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        audioSource = obj.GetComponent<AudioSource>();
        audioSource.clip = flyClip;
        animator = obj.GetComponent<Animator>();
        animator.SetFloat("flyPower", 0);
        animator.SetBool("isDead", false);

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
                audioSource.Play();
                obj.GetComponent<Rigidbody2D>().velocity = Vector2.up * flyPower;
            }
        }
        animator.SetFloat("flyPower", obj.GetComponent<Rigidbody2D>().velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        EndGame();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.GetComponent<GameController>().GetPoint();    
    }

    void EndGame()
    {   
        animator.SetBool("isDead", true);
        audioSource.clip = deathClip;
        audioSource.Play();

        Invoke(nameof(PlayGameOverSound), 1f);
        gameController.GetComponent<GameController>().EndGame();
    }

    void PlayGameOverSound()
    {
        audioSource.clip = gameOverClip;
        audioSource.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float time;
    [SerializeField] private GameObject menuPanel;
    private Vector2 targetPosition = new Vector2(3, 0);
    private Vector2 startPosition;
    private Image _menuImage;
    private Animator _menuAnimator;
    [SerializeField] private GameController _gameController;
    [SerializeField] private AudioClip rocketSound;
    private void Start()
    {
        gameObject.SetActive(false);
        startPosition = transform.position;
        _menuImage = menuPanel.GetComponent<Image>();
        _menuAnimator = menuPanel.GetComponent<Animator>();

    }
    private void FixedUpdate()
    {
        if (gameObject.activeSelf == false) return;

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            StartCoroutine(Flash());
        }
    }
    IEnumerator Flash()
    {
        _menuAnimator.SetTrigger("Faded");
        Debug.Log("Fade");
        yield return new WaitForSeconds(time);
        HideAllPoints();
        _menuAnimator.ResetTrigger("Faded");
        gameObject.SetActive(false);
    }
    public void ActiveRocket(int value)
    {
        int number = PlayerPrefs.GetInt("Rocket", 0);
        if(number <= 0) return;
        number -= value;
        SoundManager.instance.PlaySound(rocketSound);
        PlayerPrefs.SetInt("Rocket", number);
        transform.position = startPosition;
        gameObject.SetActive(true);
        Debug.Log("Ban ten lua");
    }
    private void HideAllPoints()
    {
        GameObject[] points = GameObject.FindGameObjectsWithTag("Point");

        foreach (GameObject point in points)
        {
            if(point.activeSelf == true)
            {
                _gameController.GetPoint();
                point.SetActive(false);
            }
        }
    }
}

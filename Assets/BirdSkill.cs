using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdSkill : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject shield;
    [SerializeField] private float time;
    private Collider2D birdCollier2D;
    private int protection;
    private int rocket;
    [SerializeField] private Rocket rocketScript;
    [SerializeField] private Text rocketText;
    [SerializeField] private Text protectionText;
    [SerializeField] private GameController gameController;
    private void Awake()
    {
        birdCollier2D = GetComponent<Collider2D>();
        protection = PlayerPrefs.GetInt("Protection", 0);
        Debug.Log(protection);
        gameController.UIUpdate(rocketText);
        gameController.UIUpdate(protectionText);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {        
                ActiveShield(1);

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            
            ActiveRocket();
        }
    }
    #region
    public void ActiveShield(int value)
    {
        if (protection <= 0) return;
        protection -= value;
        PlayerPrefs.SetInt("Protection", protection);
        Debug.Log("Nhan dc su bao ve than thanh");
        shield.SetActive(true);
        IgnoreWallCollision(true);
        gameController.UIUpdate(protectionText);
        Invoke("DeactiveShield", time);
    }
    public void DeactiveShield()
    {
        shield.SetActive(false);
        IgnoreWallCollision(false);
    }
    private void IgnoreWallCollision(bool ignore)
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (GameObject item in walls)
        {
            Collider2D wallCollider2D = item.GetComponent<Collider2D>();
            if (wallCollider2D != null)
            {
                Physics2D.IgnoreCollision(birdCollier2D, wallCollider2D, ignore);
            }
        }
    }
    #endregion

    public void ActiveRocket()
    {
        rocketScript.ActiveRocket(1);
        gameController.UIUpdate(rocketText);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGameController : MonoBehaviour
{
    [SerializeField] private Text txt_highScore;
    [SerializeField] private GameObject ScorePanel;
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject ShopPanel;
    // Update is called once per frame
    private void Awake()
    {
        ScorePanel.SetActive(false);
        MenuPanel.SetActive(true);
    }

    public void ShowHighScore()
    {
        SoundManager.instance.ClickButton();
        if (PlayerPrefs.HasKey("HighScore") == true)
        {
            int highScore = PlayerPrefs.GetInt("HighScore");
            txt_highScore.text = "" + highScore;
        }
        else
        {
            txt_highScore.text = "0";
        }
    }
    public void OKButton()
    {
        SoundManager.instance.ClickButton();
        if (ScorePanel.activeSelf == true)
        {
            ScorePanel.SetActive(false);
        }
        else if (ShopPanel.activeSelf == true)
        {
            ShopPanel.SetActive(false);
        }
        MenuPanel.SetActive(true);
    }
    public void ScoreButton()
    {
        MenuPanel.SetActive(false);
        ScorePanel.SetActive(true);
        ShowHighScore();
    }
    public void StartButton()
    {
        SoundManager.instance.ClickButton();
        SceneManager.LoadScene(1);
    }
    public void ShareButton()
    {
        string ShareURL = "https://www.youtube.com/watch?v=WvsmUIu0sgc";
        Application.OpenURL(ShareURL);
    }
    public void ShopButton()
    {
        SoundManager.instance.ClickButton();
        MenuPanel.SetActive(false);
        ShopPanel.SetActive(true);
    }
    
}

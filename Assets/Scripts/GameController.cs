using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public bool isEndGame;
    bool isStartFirstTime = true;
    int gamePoint = 0;

    public GameObject pnlEndGame;
    public GameObject pnlPauseGame;
    public GameObject pnlMenuGame;

    public Sprite[] numberSprites; 
    public Image[] scoreImages; 


    void Start()
    {
        Time.timeScale = 0;
        isEndGame = false;
        isStartFirstTime = true;
        pnlEndGame.SetActive(false);
        pnlMenuGame.SetActive(true);
        UpdateScoreDisplay(0); 
    }

    // Update is called once per frame
    void Update()
    {
        if (isEndGame)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isStartFirstTime)
            {
                StartGame();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1;
            }
        }
    }

    public void GetPoint()
    {
        gamePoint++;
        UpdateScoreDisplay(gamePoint); 
    }

    void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Restart()
    {
        StartGame();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pnlPauseGame.SetActive(true);

    }
    public void ResumeGame()
    {
        pnlPauseGame.SetActive(false);
        Time.timeScale = 1;
    }

    public void EndGame()
    {
        isEndGame = true;
        isStartFirstTime = false;
        Time.timeScale = 0;
        pnlMenuGame.SetActive(false);
        pnlEndGame.SetActive(true);
    }
    void UpdateScoreDisplay(int score)
    {
        string scoreStr = score.ToString().PadLeft(3, '0');

        for (int i = 0; i < scoreImages.Length; i++)
        {
            int digit = int.Parse(scoreStr[i].ToString());

            if (i == 2)
            {
                scoreImages[i].enabled = true;
                scoreImages[i].sprite = numberSprites[digit];
            }
            else if (i == 1 && score >= 10)
            {
                scoreImages[i].enabled = true;
                scoreImages[i].sprite = numberSprites[digit];
            }
            else if (i == 0 && score >= 100)
            {
                scoreImages[i].enabled = true;
                scoreImages[i].sprite = numberSprites[digit];
            }
            else
            {
                scoreImages[i].enabled = false;
            }
        }
    }


}

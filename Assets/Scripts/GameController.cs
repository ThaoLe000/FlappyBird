using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public bool isEndGame;
    public int gamePoint;
    [SerializeField] private Text yourScore;
    [SerializeField] private Text highScore;
    bool firsted;
    public GameObject pnlEndGame;
    public GameObject pnlPauseGame;
    public GameObject pnlMenuGame;

    public Sprite[] numberSprites;
    public Image[] scoreImages;




    void Start()
    {
        gamePoint = 0;
        Time.timeScale = 0;
        isEndGame = false;
        firsted = true;
        pnlEndGame.SetActive(false);
        pnlMenuGame.SetActive(true);
        UpdateScoreDisplay(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && pnlPauseGame.activeSelf == false && firsted == true)
        {
            Time.timeScale = 1;
            firsted = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pnlPauseGame.activeSelf == true)
        {
            ResumeGame();
        }
    }

    public void GetPoint()
    {
        gamePoint++;
        UpdateScoreDisplay(gamePoint);
    }
    public void Restart()
    {
        SoundManager.instance.ClickButton();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MenuGame()
    {
        SoundManager.instance.ClickButton();
        SceneManager.LoadScene(0);
    }


    public void PauseGame()
    {
        SoundManager.instance.ClickButton();
        Time.timeScale = 0;
        pnlPauseGame.SetActive(true);
        pnlMenuGame.SetActive(false);

    }
    public void ResumeGame()
    {
        SoundManager.instance.ClickButton();
        pnlPauseGame.SetActive(false);
        Time.timeScale = 1;
        pnlMenuGame.SetActive(true);
    }

    public void EndGame()
    {
        isEndGame = true;
        Time.timeScale = 0;
        pnlMenuGame.SetActive(false);
        pnlEndGame.SetActive(true);
        ShowHighScore();


    }
    private void ShowHighScore()
    {
        int _highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (gamePoint > _highScore)
        {
            PlayerPrefs.SetInt("HighScore", gamePoint);
            _highScore = PlayerPrefs.GetInt("HighScore", 0);
        }
        yourScore.text = gamePoint.ToString();
        highScore.text = _highScore.ToString();
    }
    private void UpdateScoreDisplay(int score)
    {
        string scoreStr = score.ToString();
        int length = scoreStr.Length;

        // Thêm khoảng cách giữa các số (tăng giá trị này nếu cần)
        float spacing = 80f;

        // Căn giữa tổng thể các số, bao gồm cả khoảng cách
        float totalWidth = length * scoreImages[0].rectTransform.sizeDelta.x + (length - 1) * spacing;
        float startX = -totalWidth / 2f;

        for (int i = 0; i < scoreImages.Length; i++)
        {
            if (i < length)
            {
                int digit = int.Parse(scoreStr[i].ToString());
                scoreImages[i].enabled = true;
                scoreImages[i].sprite = numberSprites[digit];

                // Cập nhật vị trí để căn giữa và tách xa nhau
                float posX = startX + i * (scoreImages[i].rectTransform.sizeDelta.x + spacing);
                scoreImages[i].rectTransform.anchoredPosition = new Vector2(posX, 0);
            }
            else
            {
                scoreImages[i].enabled = false;
            }
        }
    }

    public void UIUpdate(Text text)
    {
        int number = PlayerPrefs.GetInt(text.name, 0);
        Debug.Log("Giá trị lấy từ PlayerPrefs: " + number);
        text.text = number.ToString();
    }
}

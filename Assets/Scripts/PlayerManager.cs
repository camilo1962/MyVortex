using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PlayerManager : MonoBehaviour
{
    public static bool levelStarted;
    public static bool gameOver;

    public GameObject startMenuPanel;
    public GameObject gameOverPanel;

    public static int gems;
    public Text gemsText;

    public static int score;
    public Text scoreText;
    public Text highScoreText;

    void Start()
    {
        gameOver = levelStarted = false;
        Time.timeScale = 1;
        gems = 0;
        score = 0;
       
    }

    
    void Update()
    {
        gemsText.text = (PlayerPrefs.GetInt("TotalGems", 0) + gems).ToString();
        scoreText.text = "Puntos: " + score.ToString();

        Touchscreen ts = Touchscreen.current;
        if(ts != null && ts.primaryTouch.press.isPressed && !levelStarted)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            levelStarted = true;
            startMenuPanel.SetActive(false);
        }
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            PlayerPrefs.SetInt("TotalGems", PlayerPrefs.GetInt("TotalGems", 0) + gems);
            if(score > PlayerPrefs.GetInt("HighScore",0))
            {
                highScoreText.text = "Nuevo Record: " + score;

                PlayerPrefs.SetInt("HighScore", score);
            }
            this.enabled = false;
        }
    }
}

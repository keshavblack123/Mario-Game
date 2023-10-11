using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public GameObject highscoreText;
    public IntVariable gameScore;
    public GameObject pausePlayButton;
    public GameObject scoreText;
    public Transform restartButton;
    public GameObject gameOverPanel;

    private Vector3[] scoreTextPosition = {
        new Vector3(-760, 480, 0),
        new Vector3(0, 20, 0)
        };
    private Vector3[] restartButtonPosition = {
        new Vector3(890, 480, 0),
        new Vector3(0, -180, 0)
    };

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameStart()
    {
        // hide gameover panel
        gameOverPanel.SetActive(false);
        pausePlayButton.SetActive(true);
        scoreText.transform.localPosition = scoreTextPosition[0];
        restartButton.localPosition = restartButtonPosition[0];
    }

    public void SetScore(int score)
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();
    }


    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        pausePlayButton.SetActive(false);
        scoreText.transform.localPosition = scoreTextPosition[1];
        restartButton.localPosition = restartButtonPosition[1];
        // set highscore
        highscoreText.GetComponent<TextMeshProUGUI>().text = "TOP- " + gameScore.previousHighestValue.ToString("D6");
        // show
        highscoreText.SetActive(true);
    }

    private void Awake()
    {
        GameManager.instance.gameStart.AddListener(GameStart);
        GameManager.instance.gameOver.AddListener(GameOver);
        GameManager.instance.gameRestart.AddListener(GameStart);
        GameManager.instance.scoreChange.AddListener(SetScore);

    }
}

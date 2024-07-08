using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data;
using UnityEngine.SceneManagement;
using Ink.Runtime;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager Instance;

    [SerializeField] private TMP_Text  scoreText;
    [SerializeField] GameObject _menu;
    [SerializeField] private int increasePoints = 100;
    [SerializeField] private int decreasePoints = 100;

    //public bool isInitialized {  get; set; }
    public bool isInitialized;
    public int currentScore;
    private const string highScoreKey = "HighScore";
    private const string totalScoreKey = "TotalScore";
    //public int highScore;

    public int HighScore
    {
        get
        {
            return PlayerPrefs.GetInt(highScoreKey, 0);
        }
        set
        {
            PlayerPrefs.SetInt(highScoreKey, value);
        }
    }

    public int TotalScore
    {
        get
        {
            return PlayerPrefs.GetInt(totalScoreKey, 0);
        }
        set
        {
            PlayerPrefs.SetInt(totalScoreKey, value);
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Mais que um MinigameManager");
            
        }
        else
        {
            Instance = this;
        }
        
        TotalScore = PlayerPrefs.GetInt(totalScoreKey);
        Init();
        UpdateScore();
        //highScore = PlayerPrefs.GetInt(highScoreKey);
    }

    // Update is called once per frame
    void UpdateScore()
    {
        PlayerPrefs.SetInt("MINIGAME_POINTS", currentScore);
        scoreText.text = string.Format("pontos:" + currentScore);
    }

    public void IncreasePoints()
    {
        currentScore += increasePoints;
        UpdateScore();
    }

    public void DecreasePoints()
    {
        currentScore -= decreasePoints;
        UpdateScore();
    }

    public void ResetPoints()
    {
        currentScore = 0;
        UpdateScore();
    }

    private void Init()
    {
        currentScore = 0;
        isInitialized = false;
    }

    private const string MainMenu = "MainMenu";
    private const string Gameplay = "Gameplay";
    public void GoToMainMenu()
    {
        MainUIManager.Instance.UpdateHighScore();
        _menu.SetActive(true);
        Debug.Log("Current score" + currentScore);
        TotalScore += currentScore;
        UpdateScore();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void GoToGameplay()
    {
        _menu.gameObject.SetActive(false);
        isInitialized = true;

        if (SceneManager.GetActiveScene().buildIndex == 1)
            Gameplay_1_Manager.Instance.StartSpawn();
        else if (SceneManager.GetActiveScene().buildIndex == 2)
            Gameplay_2_Manager.Instance.StartSpawn();
        else if (SceneManager.GetActiveScene().buildIndex == 3)
            GameplayManager.Instance.StartSpawn();
    }


}

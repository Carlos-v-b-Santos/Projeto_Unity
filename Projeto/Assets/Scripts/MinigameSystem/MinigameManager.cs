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
    public int TotalScore = 0;
    [SerializeField] private int increasePoints = 100;
    [SerializeField] private int decreasePoints = 100;

    //public bool isInitialized {  get; set; }
    public bool isInitialized;
    public int currentScore;
    private const string highScoreKey = "HighScore";
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
        
        TotalScore = PlayerPrefs.GetInt("totalScore");
        Init();
        UpdateScore();
        //highScore = PlayerPrefs.GetInt(highScoreKey);
    }

    // Update is called once per frame
    void UpdateScore()
    {
        PlayerPrefs.SetInt("MINIGAME_POINTS", TotalScore);
        scoreText.text = string.Format("pontos:" + TotalScore);
    }

    public void IncreasePoints()
    {
        TotalScore += increasePoints;
        UpdateScore();
    }

    public void DecreasePoints()
    {
        TotalScore -= decreasePoints;
        UpdateScore();
    }

    public void ResetPoints()
    {
        TotalScore = 0;
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

        if (SceneManager.GetActiveScene().buildIndex == 2)
            Gameplay_1_Manager.Instance.StartSpawn();
        else if (SceneManager.GetActiveScene().buildIndex == 3)
            Gameplay_2_Manager.Instance.StartSpawn();
        else if (SceneManager.GetActiveScene().buildIndex == 1)
            GameplayManager.Instance.StartSpawn();
    }


}

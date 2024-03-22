using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager Instance;

    [SerializeField] private TMP_Text  scoreText;
    [SerializeField] private float score = 0.0f;
    [SerializeField] private float increasePoints = 100.0f;
    [SerializeField] private float decreasePoints = 100.0f;

    public bool isInitialized {  get; set; }
    public int CurrentScore { get; set; }
    private const string highScoreKey = "HighScore0";
    
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
        Instance = this;
        //score = PlayerPrefs.GetFloat("score");
        Init();
        UpdateScore();
    }

    // Update is called once per frame
    void UpdateScore()
    {
        PlayerPrefs.SetFloat("score", score);
        scoreText.text = string.Format("pontos:" + score);
    }

    public void IncreasePoints()
    {
        score += increasePoints;
        UpdateScore();
    }

    public void DecreasePoints()
    {
        score -= decreasePoints;
        UpdateScore();
    }

    public void ResetPoints()
    {
        score = 0.0f;
        UpdateScore();
    }

    private void Init()
    {
        CurrentScore = 0;
        isInitialized = false;
    }

    private const string MainMenu = "MainMenu";
    private const string Gameplay = "Gameplay";
    public void GoToMainMenu()
    {

    }

    public void GoToGameplay()
    {

    }


}

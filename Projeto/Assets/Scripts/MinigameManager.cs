using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data;

public class MinigameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text  scoreText;
    [SerializeField] private float score = 0.0f;
    [SerializeField] private float increasePoints = 100.0f;
    [SerializeField] private float decreasePoints = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = string.Format("pontos:" + score);
    }

    public void IncreasePoints()
    {
        score += increasePoints;
    }

    public void DecreasePoints()
    {
        score -= decreasePoints;
    }

    public void ResetPoints()
    {
        score = 0.0f;
    }


}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainUIManager : MonoBehaviour
{

    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _highScoreText;
    [SerializeField] private TMP_Text _newBestText;

    [SerializeField] private AudioClip _clickClip;

    [SerializeField] private float _animationTime;
    [SerializeField] private AnimationCurve _speedCurve;

    private IEnumerator ShowScore()
    {
        int tempScore = 0;
        _scoreText.text = tempScore.ToString();

        int currentScore = MinigameManager.Instance.CurrentScore;
        int highScore = MinigameManager.Instance.HighScore;

        if(currentScore > highScore)
        {
            _newBestText.gameObject.SetActive(true);
            MinigameManager.Instance.HighScore = currentScore;
        }
        else
        {
            _newBestText.gameObject.SetActive(false);
        }
        _highScoreText.text = MinigameManager.Instance.HighScore.ToString();

        float speed = 1 / _animationTime;
        float timeElapsed = 0f;

        while(timeElapsed < 1f)
        {
            timeElapsed += speed * Time.deltaTime;
            tempScore = (int)(_speedCurve.Evaluate(timeElapsed) * currentScore);
            _scoreText.text = tempScore.ToString();

            yield return null;
        }

        tempScore = (currentScore);
        _scoreText.text = tempScore.ToString();
    }

    private void Awake()
    {
        if(MinigameManager.Instance.isInitialized)
        {
            StartCoroutine(ShowScore());
        }
        else
        {
            _newBestText.gameObject.SetActive(false);
            _scoreText.gameObject.SetActive(false);
            _highScoreText.text = MinigameManager.Instance.HighScore.ToString();
        }
    }

    public void ClickedPlay()
    {
        SoundManager.Instance.PlaySound(_clickClip);
        MinigameManager.Instance.GoToGameplay();

    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static Unity.Collections.AllocatorManager;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class GameplayManager : MonoBehaviour
{
    #region START

    [SerializeField] private bool hasGameFinished;

    public static GameplayManager Instance;

    public List<Color> Colors;

    private void Awake()
    {
        Instance = this;

        hasGameFinished = false;
        MinigameManager.Instance.isInitialized = true;

        score = 0;
        _scoreText.text = score.ToString();
        StartCoroutine(SpawnScore());
    }

    #endregion

    #region GAME_LOGIC

    [SerializeField] private ScoreEffect _scoreEffect;

    //private void FixedUpdate()
    private void Select(InputAction.CallbackContext context)
    {

        

        //if(Input.GetMouseButton(0) && !hasGameFinished)
        if(!hasGameFinished)
        {
            Debug.Log("teste");
            if (CurrentScore == null)
            {
                Debug.Log("aq");
                //aq
                GameEnded();
                return;
            }

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (!hit.collider || !hit.collider.CompareTag("Block"))
            {
                Debug.Log("aq 1");
                //aq 1
                GameEnded();
                return;
            }

            int currentScoreId = CurrentScore.ColorId;
            int clickedScoreId = hit.collider.gameObject.GetComponent<Player>().ColorId;

            if (currentScoreId != clickedScoreId)
            {
                Debug.Log("aq 2");
                //aq 3
                GameEnded();
                return;
            }

            var t = Instantiate(_scoreEffect, CurrentScore.gameObject.transform.position, Quaternion.identity);
            t.Init(Colors[currentScoreId]);

            var tempScore = CurrentScore;

            if (CurrentScore.NextScore != null)
            {
                CurrentScore = CurrentScore.NextScore;
            }
            Destroy(tempScore.gameObject);
            
            UpdateScore();
        }
    }

    #endregion

    #region SCORE

    private int score;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private AudioClip _pointClip;

    public void UpdateScore()
    {
        score++;
        SoundManager.Instance.PlaySound(_pointClip);
        _scoreText.text = score.ToString();
    }

    [SerializeField] private float _spawnTime;
    [SerializeField] private Score _scorePrefab;
    private Score CurrentScore;

    private IEnumerator SpawnScore()
    {
        Score prevScore = null;

        while(!hasGameFinished)
        {
            var tempScore = Instantiate(_scorePrefab);

            if(prevScore == null)
            {
                prevScore = tempScore;
                CurrentScore = prevScore;
            }
            else
            {
                prevScore.NextScore = tempScore;
                prevScore = tempScore;
            }

            yield return new WaitForSeconds(_spawnTime);
        }
    }

    #endregion

    #region GAME_OVER

    [SerializeField] private AudioClip _loseClip;
    public UnityAction GameEnd;

    public void GameEnded()
    {
        GameEnd?.Invoke();
        SoundManager.Instance.PlaySound(_loseClip);
        hasGameFinished = true;
        MinigameManager.Instance.GoToMainMenu();
    }

    #endregion

    private void OnEnable()
    {
        GameManager.Instance.playerInputActions.UI.MouseClick.performed += Select;
    }

    private void OnDisable()
    {
        GameManager.Instance.playerInputActions.UI.MouseClick.performed -= Select;
    }
}

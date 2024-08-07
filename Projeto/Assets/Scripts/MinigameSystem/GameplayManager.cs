using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

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
        //MinigameManager.Instance.isInitialized = true;

        score = 0;
        _scoreText.text = score.ToString();
        //StartCoroutine(SpawnScore());
    }

    public void StartSpawn()
    {
        StartCoroutine(SpawnScore());
    }

    #endregion

    #region GAME_LOGIC

    [SerializeField] private ScoreEffect _scoreEffect;

    //private void FixedUpdate()
    private void Select(InputAction.CallbackContext context)
    {

        

        //if(Input.GetMouseButton(0) && !hasGameFinished)
        if(!hasGameFinished && MinigameManager.Instance.isInitialized)
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

            int currentScoreId = CurrentScore.colorId;
            int clickedScoreId = hit.collider.gameObject.GetComponent<MinigamePlayer>().ColorId;

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

            if (CurrentScore.nextScore != null)
            {
                CurrentScore = CurrentScore.nextScore;
            }
            Destroy(tempScore.gameObject);
            
            UpdateScore();
        }
    }

    private void B1(InputAction.CallbackContext context)
    {
        if (!hasGameFinished && MinigameManager.Instance.isInitialized)
        {
            Debug.Log("b1 apertado");
            int currentScoreId = CurrentScore.colorId;
            int pressedScoreId = 1;

            if (currentScoreId != pressedScoreId)
            {
                Debug.Log("aq 2");
                //aq 4
                GameEnded();
                return;
            }

            var t = Instantiate(_scoreEffect, CurrentScore.gameObject.transform.position, Quaternion.identity);
            t.Init(Colors[currentScoreId]);

            var tempScore = CurrentScore;

            if (CurrentScore.nextScore != null)
            {
                CurrentScore = CurrentScore.nextScore;
            }
            Destroy(tempScore.gameObject);

            UpdateScore();
        }
    }

    private void B2(InputAction.CallbackContext context)
    {
        if (!hasGameFinished && MinigameManager.Instance.isInitialized)
        {
            Debug.Log("b1 apertado");
            int currentScoreId = CurrentScore.colorId;
            int pressedScoreId = 3;

            if (currentScoreId != pressedScoreId)
            {
                Debug.Log("aq 2");
                //aq 4
                GameEnded();
                return;
            }

            var t = Instantiate(_scoreEffect, CurrentScore.gameObject.transform.position, Quaternion.identity);
            t.Init(Colors[currentScoreId]);

            var tempScore = CurrentScore;

            if (CurrentScore.nextScore != null)
            {
                CurrentScore = CurrentScore.nextScore;
            }
            Destroy(tempScore.gameObject);

            UpdateScore();
        }
    }

    private void B3(InputAction.CallbackContext context)
    {
        if (!hasGameFinished && MinigameManager.Instance.isInitialized)
        {
            Debug.Log("b1 apertado");
            int currentScoreId = CurrentScore.colorId;
            int pressedScoreId = 5;

            if (currentScoreId != pressedScoreId)
            {
                Debug.Log("aq 2");
                //aq 4
                GameEnded();
                return;
            }

            var t = Instantiate(_scoreEffect, CurrentScore.gameObject.transform.position, Quaternion.identity);
            t.Init(Colors[currentScoreId]);

            var tempScore = CurrentScore;

            if (CurrentScore.nextScore != null)
            {
                CurrentScore = CurrentScore.nextScore;
            }
            Destroy(tempScore.gameObject);

            UpdateScore();
        }
    }

    private void B4(InputAction.CallbackContext context)
    {
        if (!hasGameFinished && MinigameManager.Instance.isInitialized)
        {
            Debug.Log("b1 apertado");
            int currentScoreId = CurrentScore.colorId;
            int pressedScoreId = 2;

            if (currentScoreId != pressedScoreId)
            {
                Debug.Log("aq 2");
                //aq 4
                GameEnded();
                return;
            }

            var t = Instantiate(_scoreEffect, CurrentScore.gameObject.transform.position, Quaternion.identity);
            t.Init(Colors[currentScoreId]);

            var tempScore = CurrentScore;

            if (CurrentScore.nextScore != null)
            {
                CurrentScore = CurrentScore.nextScore;
            }
            Destroy(tempScore.gameObject);

            UpdateScore();
        }
    }

    private void B5(InputAction.CallbackContext context)
    {
        if (!hasGameFinished && MinigameManager.Instance.isInitialized)
        {
            Debug.Log("b1 apertado");
            int currentScoreId = CurrentScore.colorId;
            int pressedScoreId = 0;

            if (currentScoreId != pressedScoreId)
            {
                Debug.Log("aq 2");
                //aq 4
                GameEnded();
                return;
            }

            var t = Instantiate(_scoreEffect, CurrentScore.gameObject.transform.position, Quaternion.identity);
            t.Init(Colors[currentScoreId]);

            var tempScore = CurrentScore;

            if (CurrentScore.nextScore != null)
            {
                CurrentScore = CurrentScore.nextScore;
            }
            Destroy(tempScore.gameObject);

            UpdateScore();
        }
    }

    private void B6(InputAction.CallbackContext context)
    {
        if (!hasGameFinished && MinigameManager.Instance.isInitialized)
        {
            Debug.Log("b1 apertado");
            int currentScoreId = CurrentScore.colorId;
            int pressedScoreId = 4;

            if (currentScoreId != pressedScoreId)
            {
                Debug.Log("aq 2");
                //aq 4
                GameEnded();
                return;
            }

            var t = Instantiate(_scoreEffect, CurrentScore.gameObject.transform.position, Quaternion.identity);
            t.Init(Colors[currentScoreId]);

            var tempScore = CurrentScore;

            if (CurrentScore.nextScore != null)
            {
                CurrentScore = CurrentScore.nextScore;
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

        while(!hasGameFinished && MinigameManager.Instance.isInitialized)
        {
            var tempScore = Instantiate(_scorePrefab);

            if(prevScore == null)
            {
                prevScore = tempScore;
                CurrentScore = prevScore;
            }
            else
            {
                prevScore.nextScore = tempScore;
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
        hasGameFinished = true;
        
        
        SoundManager.Instance.PlaySound(_loseClip);
        Debug.Log("score:" + score);
        MinigameManager.Instance.currentScore = score;

        GameEnd?.Invoke();
        MinigameManager.Instance.GoToMainMenu();
    }

    #endregion

    private void OnEnable()
    {
        GameManager.Instance.playerInputActions.UI.MouseClick.performed += Select;
        GameManager.Instance.playerInputActions.Minigame.B1.performed += B1;
        GameManager.Instance.playerInputActions.Minigame.B2.performed += B2;
        GameManager.Instance.playerInputActions.Minigame.B3.performed += B3;
        GameManager.Instance.playerInputActions.Minigame.B4.performed += B4;
        GameManager.Instance.playerInputActions.Minigame.B5.performed += B5;
        GameManager.Instance.playerInputActions.Minigame.B6.performed += B6;
    }

    private void OnDisable()
    {
        GameManager.Instance.playerInputActions.UI.MouseClick.performed -= Select;
        GameManager.Instance.playerInputActions.Minigame.B1.performed -= B1;
        GameManager.Instance.playerInputActions.Minigame.B2.performed -= B2;
        GameManager.Instance.playerInputActions.Minigame.B3.performed -= B3;
        GameManager.Instance.playerInputActions.Minigame.B4.performed -= B4;
        GameManager.Instance.playerInputActions.Minigame.B5.performed -= B5;
        GameManager.Instance.playerInputActions.Minigame.B6.performed -= B6;
    }
}

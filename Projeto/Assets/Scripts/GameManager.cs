using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerInputActions playerInputActions;

    [SerializeField] float etica = 0;
    [SerializeField] float competencia = 0;
    [SerializeField] float pontos_minigame = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Mais que um GameManager");
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);


        if (Instance != null)
        {
            Debug.Log("GameManager instaciado");
        }

        playerInputActions = new PlayerInputActions();
        if (playerInputActions != null)
        {
            Debug.Log("playerInputActions instaciado");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        etica = PlayerPrefs.GetFloat("etica");
        competencia = PlayerPrefs.GetFloat("competencia");
        pontos_minigame = PlayerPrefs.GetFloat("score");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseEtica(float points)
    {
        etica += points;
    }

    public void IncreaseCompetencia(float points)
    {
        competencia += points;
    }

    private void EnterMinigame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitMinigame()
    {
        pontos_minigame = PlayerPrefs.GetFloat("score");
        SceneManager.LoadScene(0);
    }

    private void OnEnable()
    {
        playerInputActions.Enable();
       
        GameEventsManager.Instance.minigameEvents.OnEnterMinigame += EnterMinigame;
        GameEventsManager.Instance.minigameEvents.OnExitMinigame += ExitMinigame;
    }

    private void OnDisable()
    {
        playerInputActions.Disable();

        GameEventsManager.Instance.minigameEvents.OnEnterMinigame -= EnterMinigame;
        GameEventsManager.Instance.minigameEvents.OnExitMinigame -= ExitMinigame;
    }
}

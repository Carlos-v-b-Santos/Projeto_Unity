using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerInputActions playerInputActions;

    public const string minigamePointsKey = "MINIGAME_POINTS";

    [SerializeField] int indexMinigame;

    [SerializeField] int minigamePoints = 0;


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Mais que um GameManager");
            return;
        }
        Instance = this;
        //DontDestroyOnLoad(gameObject);


        if (Instance != null)
        {
            Debug.Log("GameManager instaciado");
        }

        playerInputActions = new PlayerInputActions();
        if (playerInputActions != null)
        {
            Debug.Log("playerInputActions instaciado");
        }

        minigamePoints = PlayerPrefs.GetInt(minigamePointsKey);
        
        //GameEventsManager.Instance.timeEvents.StartMorningWork();
    }

    private void EnterMinigame()
    {
        
        SceneManager.LoadScene(indexMinigame);
    }
    public void ExitMinigame()
    {
        minigamePoints = PlayerPrefs.GetInt(minigamePointsKey);
        SceneManager.LoadScene(0);
    }

    public void EndMorningWork()
    {
        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            //GameEventsManager.Instance.minigameEvents.ExitMinigame();
            
            //ExitMinigame();
            //GameEventsManager.Instance.timeEvents.StartAfternoonWork();
        }
    }

    private void OnEnable()
    {
        playerInputActions.Enable();
       
        GameEventsManager.Instance.minigameEvents.OnEnterMinigame += EnterMinigame;
        GameEventsManager.Instance.minigameEvents.OnExitMinigame += ExitMinigame;
        GameEventsManager.Instance.timeEvents.OnEndMorningWork += EndMorningWork;
    }

    private void OnDisable()
    {
        playerInputActions.Disable();

        GameEventsManager.Instance.minigameEvents.OnEnterMinigame -= EnterMinigame;
        GameEventsManager.Instance.minigameEvents.OnExitMinigame -= ExitMinigame;
        GameEventsManager.Instance.timeEvents.OnEndMorningWork -= EndMorningWork;
    }
}

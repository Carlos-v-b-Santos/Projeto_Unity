using System.Collections;
using Unity.VisualScripting;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerInputActions playerInputActions;

    public const string minigamePointsKey = "MINIGAME_POINTS";
    public const string playerNameKey = "PLAYER_NAME";

    [SerializeField] int indexMinigame;

    [SerializeField] int minigamePoints = 0;

    [SerializeField] TransitionLevel transitionLevel;
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
        //DontDestroyOnLoad(this);
    }

    public void EnterPrincipalScene()
    {
        minigamePoints = PlayerPrefs.GetInt(minigamePointsKey);
        transitionLevel.TransitionLevelAnim(1);
    }

    private void EnterMinigame()
    {

        //SceneManager.LoadScene(indexMinigame);
        transitionLevel.TransitionLevelAnim(indexMinigame);
    }
    public void ExitMinigame()
    {
        minigamePoints = PlayerPrefs.GetInt(minigamePointsKey);
        //SceneManager.LoadScene(0);
        transitionLevel.TransitionLevelAnim(1);
    }

    public void EndMorningWork()
    {
        if(SceneManager.GetActiveScene().buildIndex != 1)
        {
            //GameEventsManager.Instance.minigameEvents.ExitMinigame();
            
            //ExitMinigame();
            //GameEventsManager.Instance.timeEvents.StartAfternoonWork();
        }
        //SceneManager.LoadScene(0);
        transitionLevel.TransitionLevelAnim(1);

        TimeSystem.Instance.StartTimeSystemAfternoon();
    }

    

    private void EndWorkingDay()
    {
        
    }

    private void OnEnable()
    {
        playerInputActions.Enable();
       
        GameEventsManager.Instance.minigameEvents.OnEnterMinigame += EnterMinigame;
        GameEventsManager.Instance.minigameEvents.OnExitMinigame += ExitMinigame;
        GameEventsManager.Instance.timeEvents.OnEndMorningWork += EndMorningWork;
        GameEventsManager.Instance.timeEvents.OnEndWorkingDay += EndWorkingDay;
    }

    private void OnDisable()
    {
        playerInputActions.Disable();

        GameEventsManager.Instance.minigameEvents.OnEnterMinigame -= EnterMinigame;
        GameEventsManager.Instance.minigameEvents.OnExitMinigame -= ExitMinigame;
        GameEventsManager.Instance.timeEvents.OnEndMorningWork -= EndMorningWork;
    }
}

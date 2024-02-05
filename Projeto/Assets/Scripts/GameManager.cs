using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float etica = 0;
    [SerializeField] float competencia = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseEtica(float points)
    {
        etica += points;
    }

    public void increaseCompetencia(float points)
    {
        competencia += points;
    }

    private void EnterMinigame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitMinigame()
    {
        SceneManager.LoadScene(0);
    }

    private void OnEnable()
    {
        GameEventsManager.Instance.minigameEvents.OnEnterMinigame += EnterMinigame;
        GameEventsManager.Instance.minigameEvents.OnExitMinigame += ExitMinigame;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.minigameEvents.OnEnterMinigame -= EnterMinigame;
        GameEventsManager.Instance.minigameEvents.OnExitMinigame -= ExitMinigame;
    }
}

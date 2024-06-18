using System;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
//Reponsável por centralizar todos os eventos possiveis no jogo
{
    public static GameEventsManager Instance { get; private set; }

    public QuestEvents questEvents;
    public DialogueEvents dialogueEvents;
    public MinigameEvents minigameEvents;
    public TimeEvents timeEvents;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Mais que um GameEventManager");
        }
        Instance = this;

        if (Instance != null)
        {
            Debug.Log("GameEventManager instaciado");
        }

        //initialize all events
        questEvents = new QuestEvents();
        if (questEvents != null)
        {
            Debug.Log("questEvents instaciado");
        }

        dialogueEvents = new DialogueEvents();
        if(dialogueEvents != null)
        {
            Debug.Log("dialogueEvents instaciado");
        }

        minigameEvents = new MinigameEvents();
        if(minigameEvents != null)
        {
            Debug.Log("minigameEvents intansciado");
        }

        timeEvents = new TimeEvents();
        if (timeEvents != null)
        {
            Debug.Log("timeEvents intansciado");
        }
    }
}

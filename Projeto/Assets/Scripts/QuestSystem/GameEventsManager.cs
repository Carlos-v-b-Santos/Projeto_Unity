using System;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
//Reponsável por centralizar todos os eventos possiveis no jogo
{
    public static GameEventsManager Instance { get; private set; }

    public QuestEvents questEvents;
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
    }
}

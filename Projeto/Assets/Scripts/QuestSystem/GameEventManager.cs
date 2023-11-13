using System;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance { get; private set; }

    public QuestEvents questEvents;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Mais que um GameEventManager");
        }
        instance = this;
        if (instance != null)
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

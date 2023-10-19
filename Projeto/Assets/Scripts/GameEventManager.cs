using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager instance {  get; private set; }

    public QuestEvents questEvents;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Mais que um GameEventManager");
        }
        instance = this;

        //initialize all events
        questEvents = new QuestEvents();
    }
}

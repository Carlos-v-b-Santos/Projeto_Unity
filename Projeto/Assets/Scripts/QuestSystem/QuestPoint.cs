using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class QuestPoint : MonoBehaviour
{
    [Header("Quest")]
    [SerializeField] private QuestInfoSO questInfoForPoint;

    [Header("Config")]
    [SerializeField] private bool startPoint = true;
    [SerializeField] private bool finishPoint = true;

    private bool playerIsNear = false;
    private string questId;
    private QuestState currentQuestState;

    private void Awake()
    {
        questId = questInfoForPoint.id;
    }

    //teste
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("space key was pressed");
            SubmitPressed();
        }
    }

    private void OnEnable()
    {
        GameEventManager.instance.questEvents.onQuestStateChange += QuestStateChange;
        //GameEventManager.instance.inputEvents.onSubmitPressed += SubmitPressed;
    }

    private void OnDisable()
    {
        GameEventManager.instance.questEvents.onQuestStateChange -= QuestStateChange;
        //GameEventManager.instance.inputEvents.onSubmitPressed -= SubmitPressed;
    }

    private void SubmitPressed()
    {
        

        if (!playerIsNear)
        {
            return;
        }

        if(currentQuestState.Equals(QuestState.CAN_START)&& startPoint) 
        {
            Debug.Log("Quest Iniciada");
            GameEventManager.instance.questEvents.StartQuest(questId);
        }
        else if(currentQuestState.Equals(QuestState.CAN_FINISH)&& finishPoint)
        {
            Debug.Log("Quest Finalizada");
            GameEventManager.instance.questEvents.FinishQuest(questId);
        }
    }

    private void QuestStateChange(Quest quest)
    {
        //only update the quest state if this point has the correponding quest
        if(quest.info.id.Equals(questId))
        {
            currentQuestState = quest.state;
            Debug.Log("Quest with id: " + questId + "update to state: " + currentQuestState);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerIsNear = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerIsNear = false; 
    }
}

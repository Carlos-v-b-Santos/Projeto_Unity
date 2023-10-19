using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private Dictionary<string, Quest> questMap;

    private void Awake()
    {
        questMap = CreateQuestMap();

        Quest quest = GetQuestById("TestQuest");
        Debug.Log(quest.info.displayName);
        //Debug.Log(quest.info.levelRequirement);
        Debug.Log(quest.state);
        Debug.Log(quest.CurrentStepExists());
    }

    private void OnEnable()
    {
        GameEventManager.instance.questEvents.onStartQuest += StartQuest;
        GameEventManager.instance.questEvents.onAdvanceQuest += AdvanceQuest;
        GameEventManager.instance.questEvents.onFinishQuest += FinishQuest;
    }

    private void OnDisable()
    {
        GameEventManager.instance.questEvents.onStartQuest -= StartQuest;
        GameEventManager.instance.questEvents.onAdvanceQuest -= AdvanceQuest;
        GameEventManager.instance.questEvents.onFinishQuest -= FinishQuest;
    }

    private void Start()
    {
        // broadcast the initial state of all quests on startup
        foreach(Quest quest in questMap.Values)
        {
            GameEventManager.instance.questEvents.QuestStateChance(quest);
        }
    }

    private void ChangeQuestState(string id, QuestState state)
    {
        Quest quest = GetQuestById(id);
        quest.state = state;
        GameEventManager.instance.questEvents.QuestStateChance(quest);
    }

    private bool CheckRequirementsMet(Quest quest)
    {
        bool meetsRequirements = true;

        //if(currentPlayerLevel < quest.info.levelRequirement)
        //{
        //    meetsRequirements = false;
        //}

        foreach (QuestInfoSO prerequisiteQuestInfo in quest.info.questPrerequisites)
        {
            meetsRequirements = false;
        }

        return meetsRequirements;
    }


    private void Update()
    {
        foreach (Quest quest in questMap.Values)
        {
            if(quest.state == QuestState.REQUIREMENTS_NOT_MET && CheckRequirementsMet(quest))
            {
                ChangeQuestState(quest.info.id, QuestState.CAN_START);
            }
        }
    }
    private void StartQuest(string id)
    {
        Debug.Log("Start Quest:" + id);
    }

    private void AdvanceQuest(string id)
    {
        Debug.Log("Advance Quest:" + id);
    }

    private void FinishQuest(string id)
    {
        Debug.Log("Finish Quest:" + id);
    }
    private Dictionary<string, Quest> CreateQuestMap()
    {
        // Loads all QuestInfoSO Scriptable Objects under the Assets/Resources/Quests folder
        QuestInfoSO[] allQuests = Resources.LoadAll<QuestInfoSO>("Quests");
        
        // Create the quest map
        Dictionary<string,Quest> idToQuestMap = new Dictionary<string, Quest>();
        foreach (QuestInfoSO questInfo in allQuests)
        {
            if(idToQuestMap.ContainsKey(questInfo.id))
            {
                Debug.LogWarning("id duplicado:" + questInfo.id);
            }
            idToQuestMap.Add(questInfo.id, new Quest(questInfo));
        }
        return idToQuestMap;
    }

    private Quest GetQuestById(string id)
    {
        Quest quest = questMap[id];
        if (quest == null)
        {
            Debug.LogError("ID nao encontrado" + id);
        }
        return quest;
    }
}
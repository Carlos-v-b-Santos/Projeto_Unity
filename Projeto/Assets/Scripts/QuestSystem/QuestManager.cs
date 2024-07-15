using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] Player player;

    [Header("Config")]
    [SerializeField] private bool loadQuestState = true;
    
    private Dictionary<string, Quest> questMap;


    private void Awake()
    {
        questMap = CreateQuestMap();

        //Quest quest = GetQuestById("TestQuest");
        //Quest quest = GetQuestById("Mission0");
        //Debug.Log(quest.info.displayName);
        //Debug.Log(quest.info.levelRequirement);
        //Debug.Log(quest.state);
        //Debug.Log(quest.CurrentStepExists());
    }

    private void OnEnable()
    {
        GameEventsManager.Instance.questEvents.OnStartQuest += StartQuest;
        GameEventsManager.Instance.questEvents.OnAdvanceQuest += AdvanceQuest;
        GameEventsManager.Instance.questEvents.OnFinishQuest += FinishQuest;

        GameEventsManager.Instance.questEvents.OnQuestStepStateChange += QuestStepStateChange;

    }

    private void OnDisable()
    {
        GameEventsManager.Instance.questEvents.OnStartQuest -= StartQuest;
        GameEventsManager.Instance.questEvents.OnAdvanceQuest -= AdvanceQuest;
        GameEventsManager.Instance.questEvents.OnFinishQuest -= FinishQuest;

        GameEventsManager.Instance.questEvents.OnQuestStepStateChange -= QuestStepStateChange;
    }

    private void Start()
    {
        // broadcast the initial state of all quests on startup
        foreach(Quest quest in questMap.Values)
        {
            if (quest.state == QuestState.IN_PROGRESS)
            {
                quest.InstantiateCurrentQuestStep(this.transform);
            }
            GameEventsManager.Instance.questEvents.QuestStateChance(quest);
        }
    }

    private void ChangeQuestState(string id, QuestState state)
    {
        Quest quest = GetQuestById(id);
        quest.state = state;
        GameEventsManager.Instance.questEvents.QuestStateChance(quest);
    }

    private bool CheckRequirementsMet(Quest quest)
    {
        bool meetsRequirements = true;


        //if(currentPlayerLevel < quest.info.levelRequirement)
        //{
        //    meetsRequirements = false;
        //}

        // check quest prerequisites for completion
        foreach (QuestInfoSO prerequisiteQuestInfo in quest.info.questPrerequisites)
        {
            if (GetQuestById(prerequisiteQuestInfo.Id).state != QuestState.FINISHED)
            {
                meetsRequirements = false;
            }
        }

        return meetsRequirements;
    }


    private void Update()
    {
        //rastreia continuamente todas as quests
        foreach (Quest quest in questMap.Values)
        {
            //se todos os requisitos foram cumpridos
            if(quest.state == QuestState.REQUIREMENTS_NOT_MET && CheckRequirementsMet(quest))
            {
                ChangeQuestState(quest.info.Id, QuestState.CAN_START);
            }
        }
    }
    private void StartQuest(string id)
    {
        Debug.Log("Start Quest:" + id);
        Quest quest = GetQuestById(id);
        quest.InstantiateCurrentQuestStep(this.transform);
        ChangeQuestState(quest.info.Id, QuestState.IN_PROGRESS);
    }

    private void AdvanceQuest(string id)
    {
        Debug.Log("Advance Quest:" + id);
        Quest quest = GetQuestById(id);

        quest.MoveToNextStep();

        if(quest.CurrentStepExists())
        {
            quest.InstantiateCurrentQuestStep(this.transform);
        }
        else
        {
            ChangeQuestState(quest.info.Id, QuestState.CAN_FINISH);
        }

        SaveQuest(quest);
    }

    private void FinishQuest(string id)
    {
        Debug.Log("Finish Quest:" + id);
        Quest quest = GetQuestById(id);
        ClaimRewards(quest);
        ChangeQuestState(quest.info.Id, QuestState.FINISHED);
        SaveQuest(quest);
    }

    private void ClaimRewards(Quest quest)
    {
        //player.EthicMeterIncrease(quest.info.ethicsPointsReward);
        //enviar eventos para entregar a recompensa
        //GameEventsManager.instance.goldEvents.GoldGained(quest.info.goldReward);
        //GameEventsManager.instance.playerEvents.ExperienceGained(quest.info.experienceReward);
    }

    private void QuestStepStateChange(string id, int stepIndex, QuestStepState questStepState)
    {
        Quest quest = GetQuestById(id);
        quest.StoreQuestStepState(questStepState, stepIndex);
        ChangeQuestState(id, quest.state);
    }
    private Dictionary<string, Quest> CreateQuestMap()
    {
        // Loads all QuestInfoSO Scriptable Objects under the Assets/Resources/Quests folder
        QuestInfoSO[] allQuests = Resources.LoadAll<QuestInfoSO>("Quests");
        
        // Create the quest map
        Dictionary<string,Quest> idToQuestMap = new Dictionary<string, Quest>();
        foreach (QuestInfoSO questInfo in allQuests)
        {
            Debug.Log("questinfo id: " + questInfo.Id);
            if(idToQuestMap.ContainsKey(questInfo.Id))
            {
                Debug.LogWarning("id duplicado:" + questInfo.Id);
            }
            idToQuestMap.Add(questInfo.Id, LoadQuest(questInfo));
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

    private void OnApplicationQuit()
    {
        //foreach(Quest quest in questMap.Values)
        //{
        //    QuestData questData = quest.GetQuestData();
        //    Debug.Log(quest.info.Id);
        //    Debug.Log("state = " + questData.state);
        //    Debug.Log("index = " + questData.questStepIndex);
        //    foreach (QuestStepState stepState in questData.questStepStates)
        //    {
        //        Debug.Log("step state = " + stepState.state);
        //    }
        //}

        foreach (Quest quest in questMap.Values)
        {
            SaveQuest(quest);
        }
    }
    
    private void SaveQuest(Quest quest)
    {
        try
        {
            QuestData questData = quest.GetQuestData();
            string serializedData = JsonUtility.ToJson(questData);
            // saving to PlayerPrefs is just a quick example for this tutorial video,
            // you probably don't want to save this info there long-term.
            // instead, use an actual Save & Load system and write to a file, the cloud, etc..
            PlayerPrefs.SetString(quest.info.Id, serializedData);

            Debug.Log(serializedData);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to save quest with id" + quest.info.Id + ":" + e);
            //throw;
        }
    }

    private Quest LoadQuest(QuestInfoSO questInfo)
    {
        Quest quest = null;
        try
        {
            //carrega a quest do data salvo
            if(PlayerPrefs.HasKey(questInfo.Id) && loadQuestState)
            {
                string serializedData = PlayerPrefs.GetString(questInfo.Id);
                QuestData questData = JsonUtility.FromJson<QuestData>(serializedData);
                quest = new Quest(questInfo, questData.state, questData.questStepIndex, questData.questStepStates);
            }
            else
            {
                quest = new Quest(questInfo);

            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("falha ao carregar QuestId" + quest.info.Id + ":" + e);
        }
        return quest;
    }
}
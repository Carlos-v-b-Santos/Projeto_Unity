using Ink.Parsed;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    // informacao estatica
    public QuestInfoSO info;

    // informacao de estado
    public QuestState state;
    private int currentQuestStepIndex;
    private QuestStepState[] questStepStates;

    public Quest(QuestInfoSO questInfo)
    //construtor de quests nao iniciadas
    {
        this.info = questInfo;
        this.state = QuestState.REQUIREMENTS_NOT_MET;
        this.currentQuestStepIndex = 0;
        this.questStepStates = new QuestStepState[info.questStepPrefabs.Length];
        
        for (int i = 0;i < info.questStepPrefabs.Length;i++)
        {
            questStepStates[i] = new QuestStepState();
        }
    }

    public Quest(QuestInfoSO questInfo, QuestState questState, int currentQuestStepIndex, QuestStepState[] questStepStates)
    //construtor de Quests ja iniciadas
    {
        this.info = questInfo;
        this.state = questState;
        this.currentQuestStepIndex = currentQuestStepIndex;
        this.questStepStates = questStepStates;

        if(this.questStepStates.Length != this.info.questStepPrefabs.Length)
        {
            Debug.LogWarning("tamanhos diferentes, problema de sincronizacao" + this.info.Id);
        }
    }

    public void MoveToNextStep()
    {
        this.currentQuestStepIndex++;
    }

    public bool CurrentStepExists()
    {
        return (currentQuestStepIndex < info.questStepPrefabs.Length);
    }

    public void InstantiateCurrentQuestStep(Transform parentTransform)
    {
        GameObject questStepPrefab = GetCurrentQuestPrefab();
        if (questStepPrefab != null)
        {
            QuestStep questStep = UnityEngine.Object.Instantiate<GameObject>(questStepPrefab, parentTransform).GetComponent<QuestStep>();
            questStep.InitializeQuestStep(info.Id, currentQuestStepIndex, questStepStates[currentQuestStepIndex].state);
        }
    }

    private GameObject GetCurrentQuestPrefab()
    {
        GameObject questStepPrefab = null;
        if(CurrentStepExists())
        { 
            questStepPrefab = info.questStepPrefabs[currentQuestStepIndex];
        }
        else
        {
            Debug.LogWarning("Tentei encontrar o Prefab, mas o index nao existe. Quest Index:" + info.Id + "index do passo:" + currentQuestStepIndex);
        }
        return questStepPrefab;
    }

    public void StoreQuestStepState(QuestStepState questStepState, int stepIndex)
    {
        if(stepIndex < questStepStates.Length)
        {
            questStepStates[stepIndex].state = questStepState.state;
        }
        else
        {
            Debug.LogWarning("stepIndex fora de range:" + info.Id + " stepIndex:" + stepIndex);
        }
    }

    public QuestData GetQuestData()
    {
        return new QuestData(state, currentQuestStepIndex, questStepStates);
    }
}

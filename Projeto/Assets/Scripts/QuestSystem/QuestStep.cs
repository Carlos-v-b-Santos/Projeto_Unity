using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestStep : MonoBehaviour
{
    [SerializeField] private bool isFinished = false;
    private string questId;
    private int stepIndex;

    public void InitializeQuestStep(string questId, int stepIndex, string questStepState)
    {
        this.questId = questId;
        this.stepIndex = stepIndex;
        if(questStepState != null && questStepState != "")
        {
            SetQuestStepState(questStepState);
        }
    }
    protected void FinishQuestStep()
    {
        Debug.Log("para finalizar dnv");
        if (!isFinished)
        {
            Debug.Log("finalizado");
            isFinished = true;
            GameEventsManager.Instance.questEvents.AdvanceQuest(questId);
            
            Destroy(this.gameObject);
        }
    }

    protected void ChangeState(string newState)
    {
        GameEventsManager.Instance.questEvents.QuestStepStateChange(questId,stepIndex, new QuestStepState(newState));
    }

    protected abstract void SetQuestStepState(string state);
}

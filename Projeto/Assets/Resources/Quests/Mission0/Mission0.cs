using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission0 : QuestStep
{

    protected override void SetQuestStepState(string state)
    {
        //this.coinsCollected = System.Int32.Parse(state);
        //UpdateState();
    }

    //------------------------------------------------------
    private void OnEnable()
    {
        GameEventsManager.Instance.dialogueEvents.OnFinishQuestStep += FinishQuestStep;
    }
    private void OnDisable()
    {
        GameEventsManager.Instance.dialogueEvents.OnFinishQuestStep -= FinishQuestStep;
    }
}

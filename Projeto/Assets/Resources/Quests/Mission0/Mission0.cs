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
        DialogueManager.instance.Finalizar += FinishQuestStep;
    }
    private void OnDisable()
    {
        DialogueManager.instance.Finalizar -= FinishQuestStep;
    }
}

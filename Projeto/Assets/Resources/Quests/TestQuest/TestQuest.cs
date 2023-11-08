using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class TestQuest : QuestStep
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            FinishQuestStep();
        }
    }


    //FinishQuestStep();

    //private void UpdateState()
    //{
        //string state = coinsCollected.ToString();
        //ChangeState(state);
    //}

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

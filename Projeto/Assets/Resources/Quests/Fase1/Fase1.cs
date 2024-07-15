using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fase1 : QuestStep
{
    [SerializeField] Vector2 pos;
    [SerializeField] protected int minDay = 0;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    Collider2D collider2d;
    

    private void Start()
    {
        Debug.Log("missão iniciada");
        collider2d = GetComponent<Collider2D>();
        collider2d.enabled = false;
    }

    private void Update()
    {
        if(TimeSystem.Instance.Day >= minDay)
        {
            collider2d.enabled = true;
        }
    }

    protected override void SetQuestStepState(string state)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            Debug.Log("player entrou na area");
            GameEventsManager.Instance.dialogueEvents.EnterDialogue(inkJSON);
        }
    }

    private void OnEnable()
    {
        GameEventsManager.Instance.dialogueEvents.OnFinishQuestStep += FinishQuestStep;
    }
    private void OnDisable()
    {
        GameEventsManager.Instance.dialogueEvents.OnFinishQuestStep -= FinishQuestStep;
    }
}

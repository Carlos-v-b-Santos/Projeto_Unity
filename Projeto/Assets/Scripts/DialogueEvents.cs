using System;
using UnityEngine;

public class DialogueEvents
//Envia todos os eventos relacionado ao sistema de dialogo
{
    public event Action<TextAsset> OnEnterDialogue;
    public void EnterDialogue(TextAsset textAsset)
    {
        OnEnterDialogue?.Invoke(textAsset);
    }

    public event Action OnExitDialogue;
    public void ExitDialogue()
    {
        OnExitDialogue?.Invoke();
    }

    public event Action OnFinishQuestStep;
    public void FinishQuestStep()
    {
        Debug.Log("finalizando...");
        OnFinishQuestStep?.Invoke();
    }
}

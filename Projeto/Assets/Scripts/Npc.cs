using UnityEngine;

public class Npc : MonoBehaviour
{
    //private PlayerInputActions playerInputActions;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    void OnMouseDown()
    {
        GameEventsManager.Instance.dialogueEvents.EnterDialogue(inkJSON);
        //DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }
}

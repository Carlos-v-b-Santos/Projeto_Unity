using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Npc : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    // Start is called before the first frame update
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        
        GameEventsManager.Instance.dialogueEvents.EnterDialogue(inkJSON);
        //DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }
}

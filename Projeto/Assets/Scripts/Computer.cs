using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {

    }

    void OnMouseDown()
    {
        Debug.Log("computador clicado");
        GameEventsManager.Instance.minigameEvents.EnterMinigame();
        //DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }
}

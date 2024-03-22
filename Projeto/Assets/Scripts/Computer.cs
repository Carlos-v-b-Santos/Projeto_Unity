using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Computer : MonoBehaviour
{
    //UnityEvent m_MyEvent;
    private bool playerIsNear = false;

    private void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("interagir pc");
        //RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position, lookDirection, 2f, LayerMask.GetMask("Interactable"));
        if (!playerIsNear)
        {
            Debug.Log("player longe");
            return;
        }

        Debug.Log("computador interagir");
        GameEventsManager.Instance.minigameEvents.EnterMinigame();
    }

    private void OnEnable()
    {
        Debug.Log("interagir pc inscrito");
        GameManager.Instance.playerInputActions.Player.Interact.performed += Interact;
    }
    private void OnDisable()
    {
        GameManager.Instance.playerInputActions.Player.Interact.performed -= Interact;
    }

    //void OnMouseDown()
    //{
    //    Debug.Log("computador clicado");
    //    GameEventsManager.Instance.minigameEvents.EnterMinigame();
    //    DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    //}

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            Debug.Log("player entrou na area");
            playerIsNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        Debug.Log("player saiu da area");
        if (otherCollider.CompareTag("Player"))
        {
            playerIsNear = false;
        }
    }
}

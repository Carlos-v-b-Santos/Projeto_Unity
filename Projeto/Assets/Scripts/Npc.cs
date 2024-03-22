using UnityEngine;
using UnityEngine.InputSystem;

public class Npc : MonoBehaviour
{
    //private PlayerInputActions playerInputActions;
    private bool playerIsNear;


    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    //void OnMouseDown()
    //{
        //GameEventsManager.Instance.dialogueEvents.EnterDialogue(inkJSON);
        //DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    //}

    private void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("interagir npc");
        //RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position, lookDirection, 2f, LayerMask.GetMask("Interactable"));
        if (!playerIsNear)
        {
            return;
        }

        Debug.Log("npc interagir");
        GameEventsManager.Instance.dialogueEvents.EnterDialogue(inkJSON);
    }

    private void OnEnable()
    {
        GameManager.Instance.playerInputActions.Player.Interact.performed += Interact;
    }
    private void OnDisable()
    {
        GameManager.Instance.playerInputActions.Player.Interact.performed -= Interact;
    }

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

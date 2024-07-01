using UnityEngine;
using UnityEngine.InputSystem;

public class Npc : MonoBehaviour
{
    //private PlayerInputActions playerInputActions;
    private bool playerIsNear;

    public string npcName;
    public string npcRole;
    [SerializeField] private int relationshipPoints = 0;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    //void OnMouseDown()
    //{
    //GameEventsManager.Instance.dialogueEvents.EnterDialogue(inkJSON);
    //DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    //}
    public void Start()
    {
        if (PlayerPrefs.HasKey(npcRole))
        {
            relationshipPoints = PlayerPrefs.GetInt(npcRole);
        }
        else
        {
            relationshipPoints = 0;
            PlayerPrefs.SetInt(npcRole, relationshipPoints);
        }
    }

    public void Update()
    {
        relationshipPoints = PlayerPrefs.GetInt(npcRole);
    }

    //public void RelationshipPointsIncrease(int points)
    //{
    //    relationshipPoints += points;
    //    PlayerPrefs.SetInt(npcName, relationshipPoints);
    //}

    //public void RelationshipPointsDecrease(int points)
    //{
    //    relationshipPoints -= points;
    //    PlayerPrefs.SetInt(npcName, relationshipPoints);
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

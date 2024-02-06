using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Computer : MonoBehaviour
{
    //UnityEvent m_MyEvent;
    private bool playerIsNear;
    Rigidbody2D rigidbody2d;

    private void Awake()
    {

    }
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        //if (m_MyEvent == null)
        //    m_MyEvent = new UnityEvent();

        //m_MyEvent.AddListener(Ping);
    }

    //void Update()
    //{
        //if (Input.anyKeyDown && m_MyEvent != null)
        //{
        //    m_MyEvent.Invoke();
        //}
    //}

    //void Ping()
    //{
    //    Debug.Log("Ping");
    //}

    private void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("interagir");
        //RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position, lookDirection, 2f, LayerMask.GetMask("Interactable"));
        if (!playerIsNear)
        {
            return;
        }

        Debug.Log("computador interagir");
        GameEventsManager.Instance.minigameEvents.EnterMinigame();
    }

    private void OnEnable()
    {
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

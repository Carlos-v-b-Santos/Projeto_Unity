using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using static Unity.Collections.AllocatorManager;

public class Player : MonoBehaviour
{
    private const string ethicMeterKey = "ETHIC_METER";
    private const string expPointsKey = "EXP_POINTS";
    private const string playerLevelKey = "PLAYER_LEVEL";
    
    [SerializeField] private int ethicMeter = 100;
    [SerializeField] private int expPoints = 0;
    [SerializeField] private int playerLevel = 0;

    [SerializeField] float moveSpeed = 10;
    Rigidbody2D rigidbody2d;
    [SerializeField] Vector2 lookDirection = new Vector2(1, 0);

    [SerializeField] private bool computerIsNear;
    [SerializeField] private bool npcIsNear;
    //float horizontalMove;
    //float verticalMove;


    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        if (PlayerPrefs.HasKey(ethicMeterKey))
        {
            ethicMeter = PlayerPrefs.GetInt(ethicMeterKey);
        }
        else
        {
            ethicMeter = 100;
        }

        expPoints = PlayerPrefs.GetInt(ethicMeterKey);
        playerLevel = PlayerPrefs.GetInt(playerLevelKey);
    }

    void FixedUpdate()
    {
        PlayerMove(GetMoveInput());

        //transform.position = position;
        //position.x = position.x + speed * horizontalMove * Time.deltaTime;
        //position.y = position.y + speed * verticalMove * Time.deltaTime;

        
    }

    private Vector2 GetMoveInput()
    {
        Vector2 playerMove = GameManager.Instance.playerInputActions.Player.Move.ReadValue<Vector2>();
        Vector2 position = rigidbody2d.position;
        position += moveSpeed * Time.deltaTime * playerMove;
        
        return position;
    }

    public void PlayerMove(Vector2 position)
    {
        rigidbody2d.MovePosition(position);
        if (!Mathf.Approximately(position.x, 0.0f) || !Mathf.Approximately(position.y, 0.0f))//para anima��o
        {
            lookDirection.Set(position.x, position.y);
            lookDirection.Normalize();
        }
    }

    public void EthicMeterIncrease(int points)
    {
        ethicMeter += points;
        PlayerPrefs.SetInt(ethicMeterKey, ethicMeter);
    }

    public void EthicMeterDecrease(int points)
    {
        ethicMeter -= points;
        PlayerPrefs.SetInt(ethicMeterKey, ethicMeter);
    }

    public void ExpPointsIncrease(int points)
    {
        expPoints += points;
        PlayerPrefs.SetInt(expPointsKey, expPoints);
    }

    public void PlayerLevelUp()
    {
        playerLevel++;
        PlayerPrefs.SetInt(playerLevelKey, playerLevel);
    }

    private void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("interagir");
        //RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position, lookDirection, 2f, LayerMask.GetMask("Interactable"));
        if (computerIsNear)
        {
            Debug.Log("interagir computer");
            GameEventsManager.Instance.minigameEvents.EnterMinigame();
        }
        //else if (npcIsNear)
        //{
        //    Debug.Log("npc interagir");
        //    GameEventsManager.Instance.dialogueEvents.EnterDialogue(inkJSON);
        //}
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Debug.Log("player entrou da area");
        if (otherCollider.CompareTag("pc"))
        {
            computerIsNear = true;
        }

        //if (otherCollider.CompareTag("npc"))
        //{
        //    npcIsNear = true;
        //}
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        Debug.Log("player saiu da area");
        if (otherCollider.CompareTag("pc"))
        {
            computerIsNear = false;
        }

        //if (otherCollider.CompareTag("npc"))
        //{
        //    npcIsNear = false;
        //}
    }

    private void OnEnable()
    {
        GameManager.Instance.playerInputActions.Player.Interact.performed += Interact;
    }
    private void OnDisable()
    {
        GameManager.Instance.playerInputActions.Player.Interact.performed -= Interact;
    }
    //void playerMove()
    //private void Move(InputAction.CallbackContext context)
    //{
    //    Vector2 playerMove = context.ReadValue<Vector2>();
    //    Vector2 position = rigidbody2d.position;
    //    position += speed * Time.deltaTime * playerMove;
    //    rigidbody2d.MovePosition(position);
    //}
    //public void Interact(InputAction.CallbackContext context)
    //{
    //    RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position, lookDirection, 2f, LayerMask.GetMask("Interactable"));
    //    if (hit.collider != null)
    //    {
    //        Debug.Log("Raycast has hit the object " + hit.collider.gameObject);
    //    }
    //}
}
    

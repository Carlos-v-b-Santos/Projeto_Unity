using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Chair : MonoBehaviour
{
    private bool playerIsNear = false;
    public Animator animator;
    public GameObject Player;
    [SerializeField] float sitDirection;

    public bool npcChair = false;

    private void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("interagir chair");
        //RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position, lookDirection, 2f, LayerMask.GetMask("Interactable"));
        if (!playerIsNear)
        {
            Debug.Log("chair longe");
            return;
        }

        Debug.Log("chair interagir");
        // GameEventsManager.Instance.minigameEvents.EnterMinigame();
        if(!animator.GetBool("IsSitting"))
        {
            animator.SetBool("IsSitting", true);
            Player.transform.position = this.transform.position;
            animator.SetBool("IsMoving", false);
            animator.SetFloat("SitDirection", sitDirection);
            
        }
        else
        {
            animator.SetBool("IsSitting", false);
        }

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
        if (otherCollider.CompareTag("Player") && !npcChair)
        {
            Debug.Log("player entrou na area");
            playerIsNear = true;
        }

        //if (otherCollider.CompareTag("npc"))
        //{
        //    Animator npcAnimator = otherCollider.GetComponent<Animator>();
        //    GameObject npcGameObject = npcAnimator.gameObject;

            //if (!npcAnimator.GetBool("IsMoving"))
            //{ 
                //npcGameObject.transform.position = this.transform.position;
            //}
        //}
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("npc") && !npcChair)
        {
            Animator npcAnimator = collision.GetComponent<Animator>();
            GameObject npcGameObject = npcAnimator.gameObject;

            Debug.Log("npc entrou na area:" + npcGameObject.name + " cadeira " + this.name);

            if (!npcAnimator.GetBool("IsMoving"))
            {
                npcAnimator.SetBool("IsMoving", false);
                
                npcAnimator.SetBool("IsSitting", true);
                npcAnimator.SetFloat("SitDirection", sitDirection);
                npcChair = true;
            }

            
        }
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        Debug.Log("player saiu da area");
        if (otherCollider.CompareTag("Player"))
        {
            playerIsNear = false;
        }
        else if (otherCollider.CompareTag("npc"))
        {
            Animator npcAnimator = otherCollider.GetComponent<Animator>();
            GameObject npcGameObject = npcAnimator.gameObject;

            npcAnimator.SetBool("IsMoving", true);
            npcAnimator.SetBool("IsSitting", false);
            npcChair = false;
        }
    }
}

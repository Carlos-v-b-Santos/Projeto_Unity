using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Unity.Collections.AllocatorManager;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 10;
    Rigidbody2D rigidbody2d;
    [SerializeField] Vector2 lookDirection = new Vector2(1, 0);
    //float horizontalMove;
    //float verticalMove;


    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //horizontalMove = Input.GetAxis("Horizontal");
        //verticalMove = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 playerMove = GameManager.Instance.playerInputActions.Player.Move.ReadValue<Vector2>();
        Vector2 position = rigidbody2d.position;
        position += speed * Time.deltaTime * playerMove;

        //transform.position = position;
        //position.x = position.x + speed * horizontalMove * Time.deltaTime;
        //position.y = position.y + speed * verticalMove * Time.deltaTime;

        rigidbody2d.MovePosition(position);
        if (!Mathf.Approximately(position.x, 0.0f) || !Mathf.Approximately(position.y, 0.0f))
        {
            lookDirection.Set(position.x, position.y);
            lookDirection.Normalize();
        }
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
    

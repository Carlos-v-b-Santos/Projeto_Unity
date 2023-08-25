using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 10;
    Rigidbody2D rigidbody2d;
    float horizontalMove;
    float verticalMove;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontalMove * Time.deltaTime;
        position.y = position.y + speed * verticalMove * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }
    //void playerMove()

}
    

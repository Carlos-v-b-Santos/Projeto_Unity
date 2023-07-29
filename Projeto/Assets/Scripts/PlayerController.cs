using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerMove();
    }

    void playerMove()
    {
        float horizontalMove;
        float verticalMove;
        horizontalMove = Time.deltaTime * speed * Input.GetAxis("Horizontal");
        verticalMove = Time.deltaTime * speed * Input.GetAxis("Vertical");
        this.transform.Translate(horizontalMove,verticalMove,0);
    }
}

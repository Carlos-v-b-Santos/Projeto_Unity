using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class MouseMove : MonoBehaviour
{
    private Camera mainCamera;
    private NavMeshAgent agent;

    private Vector2 movePlayer;

    // Start is called before the first frame updat

    private PlayerInputActions input;
    private void Awake() => input = new PlayerInputActions();
    void Start()
    {
        

        agent = GetComponent<NavMeshAgent>();
        agent.speed = 4f;
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        mainCamera = Camera.main; 

        input.Player.Click.performed += Click;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(movePlayer);
    }

    private void Click(InputAction.CallbackContext context) 
    {
        Vector2 point = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        RaycastHit2D hit = (Physics2D.Raycast(point, Vector2.zero));
        
        if(hit.collider != null && hit.rigidbody != null) {
            movePlayer = hit.point;
        }
    }

    private void StopNavigation() {
        agent.SetDestination(transform.position);
    }
    private void OnEnable() => input.Enable();
    private void OnDisable() => input.Disable();



}

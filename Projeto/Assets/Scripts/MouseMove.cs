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

    private PlayerInputActions playerInputActions;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }
    void Start()
    {
        

        agent = GetComponent<NavMeshAgent>();
        agent.speed = 4f;
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        mainCamera = Camera.main; 

        playerInputActions.Player.MouseClick.performed += Click;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, movePlayer) > 0.5f)
        {
            agent.SetDestination(movePlayer);
        }
            
    }

    private void Click(InputAction.CallbackContext context) 
    {
        Vector2 mousePosition = playerInputActions.Player.MousePosition.ReadValue<Vector2>();
        Vector2 point = mainCamera.ScreenToWorldPoint(mousePosition);
        RaycastHit2D hit = (Physics2D.Raycast(point, Vector2.zero));
        
        if(hit.collider != null && hit.rigidbody != null) {
            movePlayer = hit.point;
        }
    }

    private void StopNavigation() {
        agent.SetDestination(transform.position);
    }
    private void OnEnable()
    {
        playerInputActions.Enable();
    }
    private void OnDisable()
    {
       playerInputActions.Disable();
    }



}

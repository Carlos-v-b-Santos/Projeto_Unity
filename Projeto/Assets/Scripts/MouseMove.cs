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
        //Vector2 mousePosition = playerInputActions.Player.MousePosition.ReadValue<Vector2>();
        Ray ray = mainCamera.ScreenPointToRay(playerInputActions.Player.MousePosition.ReadValue<Vector2>());
        //RaycastHit2D hit = (Physics2D.Raycast(ray, Vector2.zero));

        RaycastHit2D[] hits2DAll = Physics2D.GetRayIntersectionAll(ray);
        for (int i = 0; i < hits2DAll.Length; ++i)
        {
            if (hits2DAll[i].collider != null)
            {
                Debug.Log("collider encontrado: " + hits2DAll[i].collider.tag);
            }
            movePlayer = hits2DAll[i].point;
        }
        
        //}
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

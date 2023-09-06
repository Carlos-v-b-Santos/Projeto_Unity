using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class MouseMove : MonoBehaviour
{
    private Camera _camera;
    private NavMeshAgent agent;

    private Vector3 _moveTarget = Vector3.zero;
    private Vector3 _direction = Vector3.zero;

    [SerializeField] float speed = 2f;
    // Start is called before the first frame updat

    private PlayerInputActions _inputMapping;
    private void Awake() => _inputMapping = new PlayerInputActions();
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 4f;
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        _camera = Camera.main; 

        _inputMapping.Player.Click.performed += Click;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Dot(_direction, transform.forward) >= .99f) 
        {
           agent.SetDestination(_moveTarget);
        }
    }

    private void Click(InputAction.CallbackContext context) 
    {
        Debug.Log("Click");

        Ray ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit, 50f)) {
            //Physics.Raycast(ray, out RaycastHit hit, 500000f);

            Debug.Log("Click2");
            if (NavMesh.SamplePosition(hit.point, out NavMeshHit navPos, .25f, 1 << 0)) {
                Debug.Log("Click3");
                _moveTarget = navPos.position;
                Debug.Log(_moveTarget);
                //_direction = (_moveTarget - transform.position).normalized;
            
                //StopNavigation();
            
                //if (Vector3.Dot(_direction, transform.forward) >= 0.25f) {
                    agent.SetDestination(_moveTarget);
                //}
            }
        }
    }

    private void StopNavigation() {
        agent.SetDestination(transform.position);
    }
    private void Run(InputAction.CallbackContext context) { }
    private void OnEnable() => _inputMapping.Enable();
    private void OnDisable() => _inputMapping.Disable();
}

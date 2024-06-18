using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMinigame_1_Controller : MonoBehaviour
{
    [SerializeField] private Vector2 _moveSpeed;
    [SerializeField] private List<Vector2> positions;

    //[HideInInspector]
    public int colorId;
    [SerializeField] private int posId;

    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        posId = 0;
        rigidbody2d = GetComponent<Rigidbody2D>();

        rigidbody2d.MovePosition(positions[posId]);
    }

    private void FixedUpdate()
    {
        float positionDifference = positions[posId].y - rigidbody2d.position.y;

        if (positionDifference != 0)
        {
            rigidbody2d.MovePosition(rigidbody2d.position + _moveSpeed * positionDifference * Time.fixedDeltaTime);
        }
    }
    private void MoveDown(InputAction.CallbackContext context)
    {
        if (posId < positions.Count-1)
        {
            posId++;
            //rigidbody2d.MovePosition(positions[posId]);
        }
    }

    private void MoveUp(InputAction.CallbackContext context)
    {
        if (posId > 0)
        {
            posId--;
            //rigidbody2d.MovePosition(positions[posId]);
        }

    }

    private void OnEnable()
    {
        GameManager.Instance.playerInputActions.Minigame_1.down.performed += MoveDown;
        GameManager.Instance.playerInputActions.Minigame_1.up.performed += MoveUp;
    }

    private void OnDisable()
    {
        GameManager.Instance.playerInputActions.Minigame_1.down.performed -= MoveDown;
        GameManager.Instance.playerInputActions.Minigame_1.up.performed -= MoveUp;
    }
}

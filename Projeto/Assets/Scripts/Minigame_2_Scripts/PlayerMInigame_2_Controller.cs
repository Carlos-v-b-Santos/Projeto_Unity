using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMinigame_2_Controller : MonoBehaviour
{
    [SerializeField] private Vector2 _moveSpeed;
    [SerializeField] private List<Vector2> positionsVertical;

    //[HideInInspector]
    public int colorId;
    [SerializeField] private int posVerticalId;

    Rigidbody2D rigidbody2d_vertical;

    // Start is called before the first frame update
    void Start()
    {
        posVerticalId = 0;
        rigidbody2d_vertical = GetComponent<Rigidbody2D>();

        rigidbody2d_vertical.MovePosition(positionsVertical[posVerticalId]);
    }

    private void FixedUpdate()
    {
        float positionDifferenceVertical = positionsVertical[posVerticalId].y - rigidbody2d_vertical.position.y;

        if (positionDifferenceVertical != 0)
        {
            rigidbody2d_vertical.MovePosition(rigidbody2d_vertical.position + _moveSpeed * positionDifferenceVertical * Time.fixedDeltaTime);
        }
    }
    private void MoveDown(InputAction.CallbackContext context)
    {
        Debug.Log("clicado");
        if (posVerticalId < positionsVertical.Count - 1)
        {
            posVerticalId++;
            //rigidbody2d.MovePosition(positions[posId]);
        }
    }

    private void MoveUp(InputAction.CallbackContext context)
    {
        Debug.Log("clicado");
        if (posVerticalId > 0)
        {
            posVerticalId--;
            //rigidbody2d.MovePosition(positions[posId]);
        }

    }

    private void OnEnable()
    {
        GameManager.Instance.playerInputActions.Minigame_2.down.performed += MoveDown;
        GameManager.Instance.playerInputActions.Minigame_2.up.performed += MoveUp;
    }

    private void OnDisable()
    {
        GameManager.Instance.playerInputActions.Minigame_2.down.performed -= MoveDown;
        GameManager.Instance.playerInputActions.Minigame_2.up.performed -= MoveUp;
    }
}

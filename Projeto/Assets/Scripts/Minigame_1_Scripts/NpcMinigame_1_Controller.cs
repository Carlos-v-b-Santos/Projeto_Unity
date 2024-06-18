using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NpcMinigame_1_Controller : MonoBehaviour
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
        if (posId < positions.Count - 1)
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

    public void MoveDodge(int pointID)
    {
        if (pointID == posId)
        {
            if (posId == positions.Count - 1)
            {
                posId--;
            }
            else//se não estiver na ultima posição, desça
            {
                posId++;
            }
        }
    }

    public void MoveCollect(int pointID)
    {
        posId = pointID;
    }
}

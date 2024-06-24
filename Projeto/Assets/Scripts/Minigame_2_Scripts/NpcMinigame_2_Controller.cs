using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class NpcMinigame_2_Controller : MonoBehaviour
{
    [SerializeField] private Vector2 _moveSpeed;
    [SerializeField] private List<Vector2> positionsHorizontal;

    //[HideInInspector]
    public bool automaticMode;
    public int colorId;
    [SerializeField] private int posHorizontalId;

    [SerializeField] GameObject Player;
    [SerializeField] GameObject NPC;
    Rigidbody2D rigidbody2d_horizontal;

    // Start is called before the first frame update
    void Start()
    {
        posHorizontalId = 0;
        rigidbody2d_horizontal = NPC.GetComponent<Rigidbody2D>();

        rigidbody2d_horizontal.MovePosition(positionsHorizontal[posHorizontalId]);
    }

    private void FixedUpdate()
    {
        float positionDifferenceHorizontal = positionsHorizontal[posHorizontalId].x - rigidbody2d_horizontal.position.x;

        if (positionDifferenceHorizontal != 0)
        {
            rigidbody2d_horizontal.MovePosition(rigidbody2d_horizontal.position + _moveSpeed * positionDifferenceHorizontal * Time.fixedDeltaTime);
        }
    }

    private void MoveLeft(InputAction.CallbackContext context)
    {
        if (automaticMode)
            return;

        if (posHorizontalId > 0)
        {
            posHorizontalId--;
            //rigidbody2d.MovePosition(positions[posId]);
        }
    }
    private void MoveRight(InputAction.CallbackContext context)
    {
        if (automaticMode)
            return;

        if (posHorizontalId < positionsHorizontal.Count - 1)
        {
            posHorizontalId++;
            //rigidbody2d.MovePosition(positions[posId]);
        }
    }

    public void MoveDodge(int pointID)
    {
        if (!automaticMode)
            return;

        if (pointID == posHorizontalId)
        {
            if (posHorizontalId == positionsHorizontal.Count - 1)
            {
                posHorizontalId--;
            }
            else//se não estiver na ultima posição, desça
            {
                posHorizontalId++;
            }
        }
    }

    //public void MoveCollect(int pointID)
    //{
    //    posHorizontalId = pointID;
    //}

    private void OnEnable()
    {
        GameManager.Instance.playerInputActions.Minigame_2.left.performed += MoveLeft;
        GameManager.Instance.playerInputActions.Minigame_2.right.performed += MoveRight;
    }

    private void OnDisable()
    {
        GameManager.Instance.playerInputActions.Minigame_2.left.performed -= MoveLeft;
        GameManager.Instance.playerInputActions.Minigame_2.right.performed -= MoveRight;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Minigame_2_Controller : MonoBehaviour
{
    public GameObject player;
    PlayerMinigame_2_Controller playerController;

    public GameObject npc;
    NpcMinigame_2_Controller npcController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<PlayerMinigame_2_Controller>();
        npcController = npc.GetComponent<NpcMinigame_2_Controller>();
    }

    private void MoveDown(InputAction.CallbackContext context)
    {
        playerController.MoveDown();
    }

    private void MoveUp(InputAction.CallbackContext context)
    {
        playerController.MoveUp();
    }

    private void MoveLeft(InputAction.CallbackContext context)
    {
        npcController.MoveLeft();
    }

    private void MoveRight(InputAction.CallbackContext context)
    {
        npcController.MoveRight();
    }

    private void OnEnable()
    {
        GameManager.Instance.playerInputActions.Minigame_2.down.performed += MoveDown;
        GameManager.Instance.playerInputActions.Minigame_2.up.performed += MoveUp;
        GameManager.Instance.playerInputActions.Minigame_2.left.performed += MoveLeft;
        GameManager.Instance.playerInputActions.Minigame_2.right.performed += MoveRight;
    }

    private void OnDisable()
    {
        GameManager.Instance.playerInputActions.Minigame_2.left.performed -= MoveLeft;
        GameManager.Instance.playerInputActions.Minigame_2.right.performed -= MoveRight;
        GameManager.Instance.playerInputActions.Minigame_2.down.performed -= MoveDown;
        GameManager.Instance.playerInputActions.Minigame_2.up.performed -= MoveUp;
    }
}

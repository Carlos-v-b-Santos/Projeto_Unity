using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockObserver : MonoBehaviour
{
    public event Action<int> MoveCollect;
    public event Action<int> MoveDodge;

    public GameObject npc;
    NpcMinigame_1_Controller npcController;

    [SerializeField] private int blockOberserID;
    // Start is called before the first frame update
    void Start()
    {
        //npcController = new NpcMinigame_1_Controller(); 
        npcController = npc.GetComponent<NpcMinigame_1_Controller>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Score_1>().colorId == 0)
        {
            npcController.MoveDodge(blockOberserID);
        }
        else
        {
            npcController.MoveCollect(blockOberserID);
        }
    }
}

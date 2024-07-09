using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase1_mov : Fase1
{
    private GameObject Player;
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("Movendo frontend");
        NpcManager.Instance.MoveNpc("Frontend_full", Player.transform.position);
    }
}

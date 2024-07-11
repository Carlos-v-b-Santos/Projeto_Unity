using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase1_mov : Fase1
{
    public List<string> npcsRole = new List<string>();
    public List<Vector3> NpcsPositions = new List<Vector3>();

    private GameObject Player;
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("Movendo frontend");
        NpcManager.Instance.MoveNpcInstant("Frontend_full", new Vector2(Player.transform.position.x + 1, Player.transform.position.y + 1));
        
        for (int i = 0; i < NpcsPositions.Count; i++)
        {
            NpcManager.Instance.MoveNpcInstant(npcsRole[i], NpcsPositions[i]);
        }
    }
}

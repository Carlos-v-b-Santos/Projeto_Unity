using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase1_3 : Fase1
{
    private GameObject Point;

    [SerializeField] List<string> NpcsRoles = new List<string>();
    [SerializeField] List<Vector3> NpcsPos = new List<Vector3>();


    // Start is called before the first frame update
    void Awake()
    {
        Point = GameObject.FindGameObjectWithTag("WorkStationPoint");

        if(TimeSystem.Instance.Day >= this.minDay)
        {
            NpcManager.Instance.MoveNpcInstant(NpcsRoles,NpcsPos);
            NpcManager.Instance.MoveNpc("Player",Point.transform.position);
        }
    }

    private void OnDestroy()
    {
        if (isFinished) NpcManager.Instance.MoveNpcInitPos(NpcsRoles);
    }
}
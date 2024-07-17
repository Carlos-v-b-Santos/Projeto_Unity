using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase1_2 : Fase1
{
    // Start is called before the first frame update
    private GameObject Player;
    private GameObject Point;

    void Awake()
    {
        //TimeSystem.Instance.StartTimeSystemAfternoon();

        Player = GameObject.FindGameObjectWithTag("Player");
        Point = GameObject.FindGameObjectWithTag("WorkStationPoint");

        NpcManager.Instance.MoveNpcInstant("Backend_Senior", new Vector2(Player.transform.position.x + 1, Player.transform.position.y + 1));
    }

    // Update is called once per frame
    void OnDestroy()
    {
        if (isFinished)
        {
            NpcManager.Instance.MoveNpc("Player", Point.transform.position);
            NpcManager.Instance.MoveNpcInitPos("Backend_Senior");
            TimeSystem.Instance.StartTimeSystemAfternoon();
        } 
    }
}

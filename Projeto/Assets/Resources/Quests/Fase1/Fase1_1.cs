using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase1_1 : Fase1
{
    public Vector3 npcMovePos;
    public Vector3 playerMovePos;

    // Start is called before the first frame update
    private void Awake()
    {
        NpcManager.Instance.MoveNpc("Player", playerMovePos);
        NpcManager.Instance.MoveNpc("Frontend_full",npcMovePos);
        
    }

    private void OnDestroy()
    {
        if (isFinished) GameEventsManager.Instance.timeEvents.EndMorningWork();
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Fase1_4 : Fase1
{
    [SerializeField] List<string> NpcsRoles = new List<string>();
    [SerializeField] List<Vector3> NpcsPos = new List<Vector3>();
    // Start is called before the first frame update
    void Awake()
    {
        if (TimeSystem.Instance.Day >= this.minDay)
        {
            NpcManager.Instance.MoveNpcInstant(NpcsRoles, NpcsPos);
            TimeSystem.Instance.PauseTimeSystem();
        }
    }

    private void OnDestroy()
    {
        GameEventsManager.Instance.timeEvents.EndMorningWork();

    }
}

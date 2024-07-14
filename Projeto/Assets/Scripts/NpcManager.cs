using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
    public static NpcManager Instance;

    public List<NavNpc> npcMap = new List<NavNpc>();
    
    //RP = relationship points
    //private const string leaderRPKey = "leaderRP";
    //private const string backendRPKey = "backendRP";
    //private const string frontendRPKey = "frontendRP";
    //private const string requirementsRPKey = "requirementsRP";
    //private const string testerRPKey = "testerRP";
    //private const string databaseRPKey = "databaseRP";

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(this);
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Mais de uma instancia");
        }

        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseRelationship(string npcRole, int value)
    {
        int temp = PlayerPrefs.GetInt(npcRole);
        temp += value;
        PlayerPrefs.SetInt(npcRole, temp);
    }

    public void DecreaseRelationship(string npcName, int value)
    {
        int temp = PlayerPrefs.GetInt(npcName);
        temp -= value;
        PlayerPrefs.SetInt(npcName, temp);
    }

    public void MoveNpc(string npcRole, Vector3 newPos)
    {
        for (int i = 0; i < npcMap.Count; i++)
        {
            if (npcRole == npcMap[i].npcRole)
            {
                Debug.Log("movendo NPC " + npcRole);
                npcMap[i].Move(newPos);
                break;
            }
        }

    }

    public void MoveNpcInstant(string npcRole, Vector3 newPos)
    {
        for (int i = 0; i < npcMap.Count; i++)
        {
            if (npcRole == npcMap[i].npcRole)
            {
                npcMap[i].MoveInstant(newPos);
                break;
            }
        }
    }

}

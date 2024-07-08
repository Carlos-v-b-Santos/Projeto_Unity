using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
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
}

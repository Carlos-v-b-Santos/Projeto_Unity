using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestInfoSO", menuName = "ScriptableObjects/QuestInfoSO", order = 1)]
public class QuestInfoSO : ScriptableObject
{
    [field: SerializeField] public string Id {  get; set; }

    [Header("General")]
    public string displayName;

    [Header("Requirements")]
    public int ethicsPoints;
    public int competencyPoints;

    //quests anteriores que devem ser completadas
    public QuestInfoSO[] questPrerequisites;

    [Header("Steps")]
    public GameObject[] questStepPrefabs;

    [Header("Rewards")]
    public int ethicsPointsReward;
    public int competencyPointsReward;

    private void OnValidate()
    {
        #if UNITY_EDITOR
        Id = this.name;
        UnityEditor.EditorUtility.SetDirty(this);
        #endif
    }
}

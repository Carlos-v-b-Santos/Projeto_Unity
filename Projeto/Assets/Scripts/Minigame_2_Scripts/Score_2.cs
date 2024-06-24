using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Score_2 : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private List<Vector3> _spawnPos;

    //[HideInInspector]
    public int colorId;
    //[HideInInspector]
    //public Score nextScore;

    private bool hasGameFinished;

    private void Awake()
    {
        hasGameFinished = false;
        transform.position = _spawnPos[Random.Range(0, _spawnPos.Count)];
        int colorCount = Gameplay_2_Manager.Instance.Colors.Count;
        colorId = Random.Range(0, colorCount);
        GetComponent<SpriteRenderer>().color = Gameplay_2_Manager.Instance.Colors[colorId];
    }

    private void FixedUpdate()
    {
        if (hasGameFinished) return;

        transform.Translate(_moveSpeed * Time.fixedDeltaTime * Vector3.left);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Gameplay_2_Manager.Instance.GameEnded();
            
        }

        if (collision.CompareTag("npc"))
        {
            Gameplay_2_Manager.Instance.GameEnded();
        }




        if (collision.CompareTag("Obstacle"))
        {
            Gameplay_2_Manager.Instance.UpdateScore();
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        Gameplay_2_Manager.Instance.GameEnd += GameEnd;
    }

    private void OnDisable()
    {
        Gameplay_2_Manager.Instance.GameEnd -= GameEnd;
    }

    private void GameEnd()
    {
        hasGameFinished = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Score_1 : MonoBehaviour
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
        int colorCount = Gameplay_1_Manager.Instance.Colors.Count;
        colorId = Random.Range(0, colorCount);
        GetComponent<SpriteRenderer>().color = Gameplay_1_Manager.Instance.Colors[colorId];
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
            Gameplay_1_Manager.Instance.UpdateScore();
            Destroy(gameObject);
        }

        if (collision.CompareTag("npc"))
        {
            Gameplay_1_Manager.Instance.UpdateScore();
            Destroy(gameObject);
        }




        if (collision.CompareTag("Obstacle"))
        {
            Gameplay_1_Manager.Instance.GameEnded();
        }
    }

    private void OnEnable()
    {
        Gameplay_1_Manager.Instance.GameEnd += GameEnd;
    }

    private void OnDisable()
    {
        Gameplay_1_Manager.Instance.GameEnd -= GameEnd;
    }

    private void GameEnd()
    {
        hasGameFinished = true;
    }
}

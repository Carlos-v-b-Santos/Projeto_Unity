using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private List<Vector3> _spawnPos;

    //[HideInInspector]
    public int colorId;
    //[HideInInspector]
    public Score nextScore;

    private bool hasGameFinished;

    private void Awake()
    {
        hasGameFinished = false;
        transform.position = _spawnPos[Random.Range(0, _spawnPos.Count)];
        int colorCount = GameplayManager.Instance.Colors.Count;
        colorId = Random.Range(0, colorCount);
        GetComponent<SpriteRenderer>().color = GameplayManager.Instance.Colors[colorId];
    }

    private void FixedUpdate()
    {
        if (hasGameFinished) return;

        transform.Translate(_moveSpeed * Time.fixedDeltaTime * Vector3.left);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            GameplayManager.Instance.GameEnded();
        }
    }

    private void OnEnable()
    {
        GameplayManager.Instance.GameEnd += GameEnd;
    }

    private void OnDisable()
    {
        GameplayManager.Instance.GameEnd -= GameEnd;
    }

    private void GameEnd()
    {
        
        hasGameFinished = true;
    }
}

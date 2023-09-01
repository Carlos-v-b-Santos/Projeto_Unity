using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float etica = 0;
    [SerializeField] float competencia = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseEtica(float points)
    {
        etica += points;
    }

    public void increaseCompetencia(float points)
    {
        competencia += points;
    }
}

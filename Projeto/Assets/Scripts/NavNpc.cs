using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Nav : MonoBehaviour
{
    //Ponto para o qual o personagem ir� se mover
    private GameObject Point;
    //Vari�vel NavMeshAgent Para configurar A movimenta��o do personagem
    private NavMeshAgent agent;
    void Start()
    {
        //Pega o Componente NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
        //Variaveis setadas como False para N�o utilizar os eixos Y Baseado em 3 dimens�es
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        // Encontra o ponto Na cena
        Point = GameObject.Find("Point");

    }


    void Update()
    {
        //Faz o personagem se locomover pelo cenario at� o point
        agent.SetDestination(Point.transform.position);
    }
}
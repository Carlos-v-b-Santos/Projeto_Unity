using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
public class NavNpc : MonoBehaviour
{
    //Ponto para o qual o personagem ir� se mover
    //private GameObject Point;
    //Vari�vel NavMeshAgent Para configurar A movimenta��o do personagem
    public bool isMoving;
    public string npcRole;
    private NavMeshAgent agent;
    private Transform transformNpc;
    [SerializeField] Vector3 initPos;

    [SerializeField] public float moveVelOriginal;
    [SerializeField] float moveVel;
    void Awake()
    {
        //Pega o Componente NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
        transformNpc = GetComponent<Transform>();
        //Variaveis setadas como False para N�o utilizar os eixos Y Baseado em 3 dimens�es
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        // Encontra o ponto Na cena
        //Point = GameObject.Find("Point");
        
        agent.speed = moveVelOriginal;
        MoveInitPos();
    }

    //private void Update()
    //{
    //    agent.SetDestination(initPos);
    //}
    //void Update()
    //{
    //Faz o personagem se locomover pelo cenario at� o point
    //agent.SetDestination(Point.transform.position);
    //}
    IEnumerator IsMoving()
    {
        isMoving = true;
        Debug.Log(npcRole + " distancia permanecente: " + agent.remainingDistance);
        while (agent.pathPending)
        {
            Debug.Log("path nao calculado");
            yield return null;
        }
        while (agent.remainingDistance != 0f)
        {
            yield return null;
        }
        
        isMoving = false;
        agent.speed = moveVelOriginal;
    }
    
    public void Move(Vector3 newPos)
    {
        agent.ResetPath();

        if (!agent.enabled)
            agent.enabled = true;

        agent.speed = moveVel;
                
        agent.SetDestination(newPos);

        StartCoroutine(IsMoving());
    }

    public void MoveInstant(Vector3 newPos)
    {
        if (!agent.enabled)
            agent.enabled = true;

        agent.ResetPath();
        agent.Warp(newPos);
    }

    public void MoveInitPos()
    {
        Move(initPos);
    }

}
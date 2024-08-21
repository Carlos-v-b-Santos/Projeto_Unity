using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
public class NavNpc : MonoBehaviour
{
    //Ponto para o qual o personagem irá se mover
    //private GameObject Point;
    //Variável NavMeshAgent Para configurar A movimentação do personagem
    public bool isMoving;
    public string npcRole;
    private NavMeshAgent agent;
    private Transform transformNpc;
    [SerializeField] Vector3 initPos;

    [SerializeField] public float moveVelOriginal;
    [SerializeField] float moveVel;

    [SerializeField] Vector2 lookDirection = new Vector2(1, 0);
    public Animator animator;
    void Awake()
    {
        //Pega o Componente NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
        transformNpc = GetComponent<Transform>();
        //Variaveis setadas como False para Não utilizar os eixos Y Baseado em 3 dimensões
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
    //Faz o personagem se locomover pelo cenario até o point
    //agent.SetDestination(Point.transform.position);
    //}
    IEnumerator IsMoving(Vector3 newPos)
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
            lookDirection.Set(newPos.x - transform.position.x,newPos.y - transform.position.y);
            lookDirection.Normalize();

            animator.SetBool("IsMoving", true);
            animator.SetFloat("Horizontal", lookDirection.x);
            animator.SetFloat("Vertical", lookDirection.y);


            yield return null;
        }

        animator.SetBool("IsMoving", false);
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

        StartCoroutine(IsMoving(newPos));
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
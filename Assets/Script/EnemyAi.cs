using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    float turnSpeed = 5f;
    float distanceToTarget = Mathf.Infinity;
    NavMeshAgent navMeshAgent;
    bool IsProvoked = false;
    EnemyHealth health;
    


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<EnemyHealth>();
    }

   
    void Update()
    {
        if (health.IsDead())
        {
           
            enabled = false;
            navMeshAgent.speed = 0;
           

        }
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (IsProvoked)
        {
            EngageTarget();

        }
        else if (distanceToTarget <= chaseRange)
        {
            IsProvoked = true;

        }
  
    }
    public void OnDamageTaken()
    {
        IsProvoked = true;
    }

    public void EngageTarget()
    {
        FaceDirection();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {

            ChaseTarget();
        }
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }
    public void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("IsAttack", false);
        GetComponent<Animator>().SetTrigger("Move");

        navMeshAgent.SetDestination(target.position);

    }
    public void AttackTarget()
    {
        GetComponent<Animator>().SetBool("IsAttack", true);

    }


    //WTF MONKEY CODE
    public void FaceDirection()
    {
        Vector3 faceDirection = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(faceDirection.x, 0, faceDirection.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }



    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = new Color(1, 1, 1, 0.75F);
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}

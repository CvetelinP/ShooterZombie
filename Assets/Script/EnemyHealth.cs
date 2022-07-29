using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float healthPoints = 100f;
    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        healthPoints -= damage;

        if (healthPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {

        if (isDead)
        {
            return;
        }
        isDead = true;
        GetComponent<Animator>().SetTrigger("Death");
        GetComponent<CapsuleCollider>().enabled = false; 

    }
}

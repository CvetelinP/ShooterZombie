using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] int damage = 10;
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackEvent()
    {
        target.TakeDamage(damage);
        target.GetComponent<DisplayDamager>().ShowDamageImpact();
    }


}

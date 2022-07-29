using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 100;

    [SerializeField] TextMeshProUGUI healthDisplay; 

    public void TakeDamage(int damage)
    {
        health -= damage; 
        healthDisplay.text = health.ToString();

        if (health <= 0)
        {
           GetComponent<DeathHandler>().HandleDeath();
        }
    }

}

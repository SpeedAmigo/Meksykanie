using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageScript : MonoBehaviour
{
    public EnemyProperties enemyProperties;

    public void TakeDamage(float damageAmount)
    {
        enemyProperties.enemyHealth -= damageAmount;

        if (enemyProperties.enemyHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void Start()
    {
        enemyProperties.enemyHealth = 10;
    }
}

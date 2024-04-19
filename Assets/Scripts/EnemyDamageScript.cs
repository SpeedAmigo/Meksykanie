using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageScript : MonoBehaviour
{
    public ParticleSystem particle;

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
        Instantiate(particle, gameObject.transform.position, Quaternion.identity);
    }

    public void Start()
    {
        enemyProperties.enemyHealth = 10;
    }
}

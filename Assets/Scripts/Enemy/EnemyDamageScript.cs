using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageScript : MonoBehaviour
{
    public ParticleSystem particle;
    public GameObject starPrefab;

    public EnemyProperties properties = new EnemyProperties();

    public void TakeDamage(float damageAmount)
    {
        properties.enemyHealth -= damageAmount;

        if (properties.enemyHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        Instantiate(particle, gameObject.transform.position, Quaternion.identity);
        Instantiate(starPrefab, gameObject.transform.position, Quaternion.identity);
    }

    public void Start()
    {
        properties.enemyHealth = 10;
    }
}

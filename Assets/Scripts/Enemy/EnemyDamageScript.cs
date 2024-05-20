using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDamageScript : MonoBehaviour
{
    public ParticleSystem particle;
    public GameObject starPrefab;
    public UnityEvent onEnemyDeath;

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
        onEnemyDeath.Invoke();

        Destroy(gameObject);
        Instantiate(particle, gameObject.transform.position, Quaternion.identity);
        Instantiate(starPrefab, gameObject.transform.position, Quaternion.identity);
    }

    public void Start()
    {
        properties.enemyHealth = 10;

        if (onEnemyDeath == null)
        {
            onEnemyDeath = new UnityEvent();
        }
    }
}

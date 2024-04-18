using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageScript : MonoBehaviour
{
    public EnemyProperties enemyProperties;
    public ProjectileProperties projectileProperties;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            if (enemyProperties.enemyHealth <= 0)
            {
                Die();
            }
            else
            {
                TakeDamage(projectileProperties.ammoType, projectileProperties.ammoDamage);
            }
        }
    }

    public void TakeDamage(int type, float damage)
    {
        projectileProperties.ammoType = type;
        projectileProperties.ammoDamage = damage;

        enemyProperties.enemyHealth -= damage;
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

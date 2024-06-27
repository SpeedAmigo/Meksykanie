using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public PlayerProperties playerProperties;
    public TankDamageScript damageScript;

    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.CompareTag("Star"))
        {
            Destroy(other.gameObject);
            playerProperties.starCount += 75;
        }

         if (other.gameObject.TryGetComponent<EnemyDamageScript>(out EnemyDamageScript enemyDamageScript))
        {
            enemyDamageScript.TakeDamage(10);
            damageScript.DecalDeActivation();
        }
    }
}

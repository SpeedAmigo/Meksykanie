using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flameScript : MonoBehaviour
{
    private float life = 5f;
    public float flameDamage = 2f;
    public float damageInterval = 1f;

    public ProjectileProperties projectile;

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent<EnemyDamageScript>(out EnemyDamageScript enemyDamageScript))
        {
            damageInterval -= Time.deltaTime;
            if (damageInterval < 0 )
            {
                enemyDamageScript.TakeDamage(FireAttack());
                damageInterval = 1;
            }     
        }
    }

    public float FireAttack()
    {
        float damage = flameDamage;
        return damage;
    }
    private void Start()
    {
        StartCoroutine(flameLifeCorutine());
    }

    private IEnumerator flameLifeCorutine()
    {
        float elapsedTime = 0f;
        while (elapsedTime < life)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}

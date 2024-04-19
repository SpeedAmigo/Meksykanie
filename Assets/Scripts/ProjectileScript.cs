using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ProjectileScript : MonoBehaviour
{
    public float life = 3f;

    private ObjectPool<ProjectileScript> _pool;
    private Coroutine _corutine;
    private SphereCollider _triggerSphereCollider;

    public ProjectileProperties properties;

    private void OnEnable()
    {
        _corutine = StartCoroutine(DeactivateProjectileAfterTime());

        _triggerSphereCollider = GetComponent<SphereCollider>();

        if (properties.ammoType != 2)
        {
            _triggerSphereCollider.enabled = false;
        }
        else
            _triggerSphereCollider.enabled= true;
  
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyDamageScript>(out EnemyDamageScript enemyDamageScript))
        {
            enemyDamageScript.TakeDamage(properties.ammoDamage);
        }

        _pool.Release(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<EnemyDamageScript>(out EnemyDamageScript enemyDamageScript))
        {
            Debug.Log("dziala");
            enemyDamageScript.TakeDamage(properties.ammoDamage);
        }
    }

    public void SetPool(ObjectPool<ProjectileScript> pool)
    {
        _pool = pool;
    }

    private IEnumerator DeactivateProjectileAfterTime()
    {
        float elapsedTime = 0f;
        while (elapsedTime < life)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _pool.Release(this);
    }
}

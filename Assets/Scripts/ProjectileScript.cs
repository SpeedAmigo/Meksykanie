using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.Pool;

public class ProjectileScript : MonoBehaviour
{
    public float life = 3f;

    private ObjectPool<ProjectileScript> _pool;
    private SphereCollider _triggerSphereCollider;
    [SerializeField] GameObject flamePrefab;

    public ProjectileProperties properties = new ProjectileProperties();
    public AmmoType type;

    private void OnEnable()
    {
        StartCoroutine(DeactivateProjectileAfterTime());
        type = AmmoManager.currentAmmoType;
        _triggerSphereCollider = GetComponent<SphereCollider>();

        if (type != AmmoType.Explosive)
        {
            _triggerSphereCollider.enabled = false;
        }
        else
            _triggerSphereCollider.enabled= true;
    }

    // Collider for Regular and Flammable Ammo
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyDamageScript>(out EnemyDamageScript enemyDamageScript))
        {
            enemyDamageScript.TakeDamage(10);
        }

        else if (collision.gameObject.CompareTag("Ground") && type == AmmoType.Flammable)
        {
            Instantiate(flamePrefab, gameObject.transform.position, Quaternion.identity);
        }

        _pool.Release(this);
    }

    // Sphere collider for Explosive Ammo
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<EnemyDamageScript>(out EnemyDamageScript enemyDamageScript))
        {
            enemyDamageScript.TakeDamage(10);
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

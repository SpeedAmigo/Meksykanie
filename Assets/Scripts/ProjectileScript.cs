using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ProjectileScript : MonoBehaviour
{
    public float life = 3f;

    private ObjectPool<ProjectileScript> _pool;
    private Coroutine _corutine;

    private void OnEnable()
    {
        _corutine = StartCoroutine(DeactivateProjectileAfterTime());
    }

    private void OnCollisionEnter(Collision collision)
    {
        _pool.Release(this);
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

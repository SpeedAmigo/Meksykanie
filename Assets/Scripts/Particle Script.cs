using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    public float life = 3f;

    private void Start()
    {
        StartCoroutine(ParticleLifeCorutine());
    }

    private IEnumerator ParticleLifeCorutine()
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

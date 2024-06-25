using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyProjectileScript : MonoBehaviour
{
    public float life;

    public void OnTriggerEnter(Collider other)
    {s
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, life);
    }
}

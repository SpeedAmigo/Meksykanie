using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.Oculus.Input;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyProjectileScript : MonoBehaviour
{
    public float life;
    
    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Projectile colider with:" + other.gameObject.name);
        if (other.gameObject.CompareTag("Hull"))
        {
            Destroy(this.gameObject);
            //Debug.Log("Destroyed");
        }
    }
 
    // Update is called once per frame
    private void Start()
    {
        Destroy(gameObject, life);
    }
}

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

[CreateAssetMenu]
public class ProjectileProperties : ScriptableObject
{
    [SerializeField] int defaultAmmoType = 1;

    public Vector3 direction;
    public Vector3 initialPosition;
    public float initialSpeed;
    public float mass;
    public float drag;
    public int ammoType;

    public void Regular(Rigidbody rb)
    {
        rb.mass = 0.25f;
        Debug.Log("you shoot regular ammo");
    }

    public void Explosive(Rigidbody rb)
    {
        rb.mass = 1f;
        Debug.Log("you shoot explosive ammo");
    }

    public void Flammable(Rigidbody rb)
    {
        rb.mass = 0.5f;
        Debug.Log("you shoot flammable ammo");
    }

    private void OnDisable()
    {
        ResetData();
    }

    private void ResetData()
    {
        ammoType = defaultAmmoType;
    }

}

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public struct ProjectileProperties
{
    public Vector3 direction;
    public Vector3 initialPosition;
    public float initialSpeed;
    public float mass;
    public float drag;

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

}

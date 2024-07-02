using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class ProjectileProperties
{
    public PlayerProperties playerProperties;

    //[SerializeField] int defaultAmmoType = 1;
    //[SerializeField] bool defaultHasAmmo = false;

    public Vector3 direction;
    public Vector3 initialPosition;
    public float initialSpeed;
    public float mass;
    public float drag;
    public int ammoType;
    public float ammoDamage;
    //public bool hasAmmo;

    public void Regular(Rigidbody rb)
    {
        rb.mass = 0.25f;
        //Debug.Log("you shoot regular ammo");
      //  ammoType = 1;
        ammoDamage = 10;
       // hasAmmo = true;
    }

    public void Explosive(Rigidbody rb)
    {
        rb.mass = 1f;
        //Debug.Log("you shoot explosive ammo");
       // ammoType = 2;
        ammoDamage = 10;
        /*
        if (playerProperties.explosivesCount <= 0)
        {
            hasAmmo = false;
        }
        else
        {
            hasAmmo = true;
            playerProperties.explosivesCount--;
        }
        */
    }

    public void Flammable(Rigidbody rb)
    {
        rb.mass = 0.5f;
        //Debug.Log("you shoot flammable ammo");
       // ammoType = 3;
        ammoDamage = 2;
        /*
        if (playerProperties.flammableCount <= 0)
        {
            hasAmmo = false;
        }
        else
        {
            hasAmmo = true;
            playerProperties.flammableCount--;
        }
        */
    }
    /*
    private void OnDisable()
    {
        ResetData();
    }

    private void ResetData()
    {
        ammoType = defaultAmmoType;
        hasAmmo = defaultHasAmmo;
    }
    */
}

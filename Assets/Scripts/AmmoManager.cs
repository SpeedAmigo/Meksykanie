using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    private Dictionary<KeyCode, AmmoType> keyToAmmoType = new Dictionary<KeyCode, AmmoType>();
    public static AmmoType currentAmmoType;

    public GameObject[] gameObjects;
    public Rigidbody rb;
    public bool hasAmmo;

    public ProjectileProperties projectileProperties= new ProjectileProperties();
    public PlayerProperties playerProperties;

    void Start()
    {
        // Map keys to corresponding ammo types
        keyToAmmoType.Add(KeyCode.Alpha1, AmmoType.Regular);
        keyToAmmoType.Add(KeyCode.Alpha2, AmmoType.Explosive);
        keyToAmmoType.Add(KeyCode.Alpha3, AmmoType.Flammable);

        currentAmmoType = AmmoType.Regular;
        ShowRegularAmmo();
        hasAmmo = true;
    }

    void Update()
    {
        // Check for key presses to switch ammo type
        foreach (var type in keyToAmmoType)
        {
            if (Input.GetKeyDown(type.Key))
            {
                if (type.Value != currentAmmoType)
                {
                    SwitchAmmoType(type.Value);
                    CurrentAmunitionSelected();
                }
            }
        }

        
    }

    void SwitchAmmoType(AmmoType newAmmoType)
    {
        currentAmmoType = newAmmoType;
        Debug.Log("Switched to " + newAmmoType.ToString() + " ammo");
    }

    void CurrentAmunitionSelected()
    {
        switch (currentAmmoType)
        {
            case AmmoType.Regular:
                ShowRegularAmmo();
                projectileProperties.Regular(rb);
                hasAmmo = true;
                break;
            case AmmoType.Explosive:
                ShowExplosiveAmmo();
                if (playerProperties.explosivesCount <= 0)
                {
                    hasAmmo = false;
                }
                else
                {
                    hasAmmo = true;
                    playerProperties.explosivesCount--;
                }
                projectileProperties.Explosive(rb);
                break;
            case AmmoType.Flammable:
                if (playerProperties.flammableCount <= 0)
                {
                    hasAmmo = false;
                }
                else
                {
                    hasAmmo = true;
                    playerProperties.flammableCount--;
                }
                ShowFlammableAmmo();
                projectileProperties.Flammable(rb);
                break;
        }
    }

    //Enabling and Disabling UI of Ammo
    private void ShowRegularAmmo()
    {
        gameObjects[0].SetActive(true);
        gameObjects[1].SetActive(false);
        gameObjects[2].SetActive(false);
    }

    private void ShowExplosiveAmmo()
    {
        gameObjects[0].SetActive(false);
        gameObjects[1].SetActive(true);
        gameObjects[2].SetActive(false);
    }

    private void ShowFlammableAmmo()
    {
        gameObjects[0].SetActive(false);
        gameObjects[1].SetActive(false);
        gameObjects[2].SetActive(true);
    }

}

public enum AmmoType
{
    Regular,
    Explosive,
    Flammable
}

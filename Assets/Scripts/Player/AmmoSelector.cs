using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AmmoSelector : MonoBehaviour
{
    private Inputs _inputs;
    public Rigidbody prefabRb;

    public GameObject[] gameObjects;

    //public ProjectileProperties properties = new ProjectileProperties();

    public ProjectileProperties properties = new ProjectileProperties();

    private void Awake()
    {
        _inputs = new Inputs();
    }

    private void OnEnable()
    {
        _inputs.Ammo.Enable();
        _inputs.Ammo.Regular.performed += Regular;
        _inputs.Ammo.Explosive.performed += Explosive;
        _inputs.Ammo.Flammable.performed += Flammable;
    }

    public void Regular(InputAction.CallbackContext context)
    {
        properties.Regular(prefabRb);
        properties.ammoType = 1;
        ShowRegularAmmo();
    }

    public void Explosive(InputAction.CallbackContext context)
    {
        properties.Explosive(prefabRb);
        properties.ammoType = 2;
        ShowExplosiveAmmo();
    }

    public void Flammable(InputAction.CallbackContext context)
    {
        properties.Flammable(prefabRb);
        properties.ammoType = 3;
        ShowFlammableAmmo();
    }

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

    private void Start()
    {
        properties.Regular(prefabRb);
        properties.ammoType = 1;
        ShowRegularAmmo();
    }
}

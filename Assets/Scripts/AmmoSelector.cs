using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AmmoSelector : MonoBehaviour
{
    private Inputs _inputs;
    public Rigidbody prefabRb;
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

    private void Regular(InputAction.CallbackContext context)
    {
        properties.Regular(prefabRb);
    }

    public void Explosive(InputAction.CallbackContext context)
    {
        properties.Explosive(prefabRb);
    }

    public void Flammable(InputAction.CallbackContext context)
    {
        properties.Flammable(prefabRb);
    }

    private void Start()
    {
        properties.Regular(prefabRb);
    }
}

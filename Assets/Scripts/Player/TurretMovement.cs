using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;
using UnityEngine.VFX;

public class TurretMovement : MonoBehaviour
{
    public GameObject vCamera;
    public GameObject turret;
    public GameObject canonPivot;

    public float rotationSpeed = 50;
    float currentLift;

    private Quaternion cameraRotation;
    private Quaternion turretRotation;
    private Quaternion canonRotation;

    // Update is called once per frame
    void Update()
    {
        TurretRotation();

        float newLift = currentLift + Input.GetAxis("Vertical") * 10 * Time.deltaTime;

        CanonLift(newLift);
    }

    private void TurretRotation()
    {
        cameraRotation = vCamera.transform.localRotation;
        turretRotation = turret.transform.rotation;

        Quaternion targetRotation = Quaternion.Euler(0f, cameraRotation.eulerAngles.y, 0f);

        float step = rotationSpeed * Time.deltaTime;
        turret.transform.rotation = Quaternion.RotateTowards(turretRotation, targetRotation, step);
    }
    private void CanonLift(float lift)
    {
        currentLift = Mathf.Clamp(lift, -10, 20);
        canonPivot.transform.localRotation = Quaternion.Euler(-lift, 0, 0);
    }
}

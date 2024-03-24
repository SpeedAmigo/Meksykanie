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

    float currentLift;

    public Quaternion cameraRotation;
    public Quaternion turretRotation;
    public Quaternion canonRotation;

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

        Vector3 eulerRotationCamera = cameraRotation.eulerAngles;

        turret.transform.localRotation = Quaternion.Euler(0, eulerRotationCamera.y, 0);
    }

    private void CanonLift(float lift)
    {
        currentLift = Mathf.Clamp(lift, -10, 20);
        canonPivot.transform.localRotation = Quaternion.Euler(-lift, 0, 0);
    }
}

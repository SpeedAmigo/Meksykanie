using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMovement : MonoBehaviour
{
    public GameObject cameraTarget;  // The camera
    public GameObject turretRotationPivot; // The rotationPivot
    public GameObject turret;   // The turret
    public GameObject canonPivot; // The cannon pivot

    public float rotationSpeed = 50; // Rotation speed for smoothness
    float currentLift;

    void Update()
    {
        TurretRotation();

        float newLift = currentLift + Input.GetAxis("Vertical") * 10 * Time.deltaTime;
        CanonLift(newLift);
    }

    private void TurretRotation()
    {
        Quaternion turretRotation = turretRotationPivot.transform.localRotation;

        // Get the current rotation of the turret
        Quaternion currentRotation = turret.transform.rotation;

        // Create the target rotation with the camera's Y rotation, keeping the current X and Z rotations
        Quaternion targetRotation = Quaternion.Euler(turretRotation.eulerAngles.x, turretRotation.eulerAngles.y, turretRotation.eulerAngles.z);

        // Smoothly rotate the turret towards the target rotation
        float step = rotationSpeed * Time.deltaTime;

        turret.transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, step);
    }

    private void CanonLift(float lift)
    {
        currentLift = Mathf.Clamp(lift, -10, 20);
        canonPivot.transform.localRotation = Quaternion.Euler(-lift, 0, 0);
    }
}

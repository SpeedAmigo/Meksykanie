using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;
using UnityEngine.VFX;

public class TurretMovement : MonoBehaviour
{
    public GameObject camera;
    public GameObject turret;
    public GameObject canonPivot;

    public Quaternion cameraRotation;
    public Quaternion turretRotation;
    public Quaternion canonRotation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TurretRotation();
        CanonLift();
    }

    private void TurretRotation()
    {
        cameraRotation = camera.transform.localRotation;

        Vector3 eulerRotationCamera = cameraRotation.eulerAngles;

        turret.transform.localRotation = Quaternion.Euler(0, eulerRotationCamera.y, 0);
    }

    private void CanonLift()
    {
        turretRotation = camera.transform.localRotation;

        Vector3 eulerRotationCanon = turretRotation.eulerAngles;

        canonPivot.transform.localRotation = Quaternion.Euler(eulerRotationCanon.x, 0, 0);

        Debug.Log(eulerRotationCanon.x);
    }
}

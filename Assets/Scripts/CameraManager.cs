using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject gObject;
    public GameObject turretRotationPivot;
    public float sensivity;

    Vector2 camRotation;

    public float lookMin = -40f;
    public float lookMax = 80f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;        
    }

    // Update is called once per frame
    void Update()
    {
        MouseInput();
    }

    private void MouseInput()
    {
        camRotation.x += Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        camRotation.y += Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

        gObject.transform.localRotation = Quaternion.Euler(camRotation.y, camRotation.x, 0);
        turretRotationPivot.transform.localRotation = Quaternion.Euler(0f, camRotation.x, 0f);
        camRotation.y = Mathf.Clamp(camRotation.y, lookMin, lookMax);
    }
}

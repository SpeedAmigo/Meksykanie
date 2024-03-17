using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Camera cam;
    public Transform target;
    public float distanceToTarget = 10;

    public float lookMax = 90f;
    public float lookMin = -90f;

    public Vector2 camRotation;

    public float sensivity;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CameraFunction();
    }
    private void CameraFunction()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

        float rotationAroundXAxis = mouseX * 180; // rotation around X axis
        float rotationAroundYAxis = mouseY * 180; // rotation around Y axis

        cam.transform.position = target.position;

        cam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundXAxis, Space.World); // X axis
        cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundYAxis); // Y axis
        
        cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));
    }
}

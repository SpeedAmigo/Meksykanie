using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject gObject;
    public float sensivity;

    Vector2 camRotation;

    public float lookMin = -90f;
    public float lookMax = 90f;

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
        camRotation.x += Input.GetAxis("Mouse X") * sensivity;
        camRotation.y += Input.GetAxis("Mouse Y") * sensivity;

        //float mouseX = Input.GetAxis("Mouse X") * sensivity;
        //float mouseY = Input.GetAxis("Mouse Y") * sensivity;

        //Debug.Log(mouseY);
        //Debug.Log(mouseX);

        gObject.transform.rotation = Quaternion.Euler(camRotation.y, camRotation.x, 0);

        camRotation.y = Mathf.Clamp(camRotation.y, lookMin, lookMax);
    }
}
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDistance : MonoBehaviour
{
    public CinemachineVirtualCamera vCam;

    // Start is called before the first frame update
    void Start()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        CamDistance();
    }

    private void CamDistance()
    {
        var componentBase = vCam.GetCinemachineComponent<Cinemachine3rdPersonFollow>();

        float mouseScroll = Input.GetAxis("Mouse ScrollWheel");

        if (mouseScroll < 0 && componentBase.CameraDistance > 3) // zooming camera towards object
        {
            componentBase.CameraDistance--;
        }
        else if (mouseScroll > 0 && componentBase.CameraDistance < 15) // doing oposite thing
        {
            componentBase.CameraDistance++;
        }

        
    }
}

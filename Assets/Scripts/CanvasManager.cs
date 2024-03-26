using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject switcherUI;
    public GameObject handleUI;
    public Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        switcherUI.SetActive(false);
        handleUI.SetActive(false);
        handleUI.transform.localPosition = new Vector3(-277, -113, 0);
    }

    // Update is called once per frame
    void Update()
    {
        GearboxUI(switcherUI, handleUI);
        HandleUI();
    }

    private void GearboxUI(GameObject switcher, GameObject handle)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            switcher.SetActive(true);
            handle.SetActive(true);
        }
        else
        {
            switcher.SetActive(false);
            handle.SetActive(false);
        }
    }

    private void HandleUI()
    {
        if (movement.maxSpeed == 10)
        {
            handleUI.transform.localPosition = new Vector3(-277, -83, 0);
        }
        if (movement.maxSpeed == 20)
        {
            handleUI.transform.localPosition = new Vector3(-277, -140, 0);
        }
        if (movement.maxSpeed == 30)
        {
            handleUI.transform.localPosition = new Vector3(-240, -83, 0);
        }
        if (movement.maxSpeed == 40)
        {
            handleUI.transform.localPosition = new Vector3(-240, -140, 0);
        }
        if (movement.speed == -600)
        {
            handleUI.transform.localPosition = new Vector3(-313, -140, 0);
        }
    }

    
}

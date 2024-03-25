using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UIElements;
using UnityEngine.Windows.Speech;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public bool _onGround;
    public float speed;
    public float maxSpeed;
    public float turnSpeed;
    public bool isInReverse;
    
    public Rigidbody rb;
    private Switcher _switcher;

    private void Awake()
    {
        _switcher = new Switcher();
    }

    private void OnEnable()
    {
        _switcher.Enable();
        _switcher.Gears.Gear1.performed += GearAction;
        _switcher.Gears.Gear2.performed += GearAction;
        _switcher.Gears.Gear3.performed += GearAction;
        _switcher.Gears.Gear4.performed += GearAction;
        _switcher.Gears.Reverse.performed += Reverse;
    }

    private void OnDisable()
    {
        _switcher.Disable();
        _switcher.Gears.Gear1.performed -= GearAction;
        _switcher.Gears.Gear2.performed -= GearAction;
        _switcher.Gears.Gear3.performed -= GearAction;
        _switcher.Gears.Gear4.performed -= GearAction;
        _switcher.Gears.Reverse.performed -= Reverse;
    }

    private void GearAction(InputAction.CallbackContext context)
    {
        int gearValue = int.Parse(context.action.name.Replace("Gear", ""));
        maxSpeed = gearValue * 10;
        isInReverse = false;
        speed = 600;
    }
    private void Reverse(InputAction.CallbackContext context)
    {
        isInReverse = true;
        speed = -600;
        maxSpeed = 10;
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        maxSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        myInput();
        SpeedLimit();
        RaycastF();
    }


    private void myInput()
    {
        if (Input.GetMouseButton(0) && Input.GetMouseButton(1) && _onGround == true) //moving forward
        {
            rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Force);
        }

        if (Input.GetMouseButton(0) && !Input.GetMouseButton(1) && _onGround == true) //Rotation to the right
        {
            rb.transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }

        if (Input.GetMouseButton(1) && !Input.GetMouseButton(0) && _onGround == true) //Rotation to the left 
        {
            rb.transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }
    }

    public void SpeedLimit()
    {
        Vector3 velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

            //Vector3 limitVel = velocity.normalized * maxSpeed;
            //rb.velocity = new Vector3(limitVel.x, 0f, limitVel.z);
        }
    }
    public void RaycastF()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), 1.5f))
        {
            _onGround = true;
        }
        else
        {
            _onGround = false;
        }
    }
}

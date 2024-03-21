using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UIElements;
using UnityEngine.Windows.Speech;

public class Movement : MonoBehaviour
{
    private bool _onGround;
    public float speed;
    public float turnSpeed;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        myInput();
        SpeedLimit();
        RaycastF();
        Switcher();
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

        if (velocity.magnitude > speed)
        {
            Vector3 limitVel = velocity.normalized * speed;
            rb.velocity = new Vector3(limitVel.x, 0f, limitVel.z);
        }
    }
    public void RaycastF()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), 1f))
        {
            _onGround = true;
            rb.drag = 20;
        }
        else
        {
            _onGround = false;
            rb.drag = 0;
        }
    }

    public void Switcher()
    {
        if (Input.GetKeyDown(KeyCode.W) && Input.GetKey(KeyCode.LeftShift) && speed < 50)
        {
            speed = speed + 10;
        }
        else if (Input.GetKeyDown(KeyCode.S) && Input.GetKey(KeyCode.LeftShift) && speed > 10)
        {
            speed = speed - 10;
        }
    }
}

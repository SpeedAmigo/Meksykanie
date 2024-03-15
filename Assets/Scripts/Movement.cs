using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
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
    }

    private void myInput()
    {
        if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
        {
            MoveForward();
        }

        if (Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
            RightTurn();
        }

        if (Input.GetMouseButton(1) && !Input.GetMouseButton(0))
        {
            LeftTurn();
        }
    }

    public void MoveForward()
    {
        rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Force);
    }

    public void LeftTurn()
    {
        rb.transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
    }

    public void RightTurn()
    {
        rb.transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
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
}

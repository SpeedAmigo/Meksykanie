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

    [SerializeField, Range(1, 60000)]
    public float acceleration;

    public float maxSpeed;
    public float turnSpeed;
    private float _previousMaxSpeed;
    public bool isInReverse;

    public bool engineWorking = true;

    public RestartUIScript restartUIScript;
    public Rigidbody rb;
    private Inputs _inputs;

    private void Awake()
    {
        _inputs = new Inputs();
    }

    private void OnEnable()
    {
        _inputs.Enable();
        _inputs.Gears.Gear1.performed += GearAction;
        _inputs.Gears.Gear2.performed += GearAction;
        _inputs.Gears.Gear3.performed += GearAction;
        _inputs.Gears.Gear4.performed += GearAction;
        _inputs.Gears.Reverse.performed += Reverse;
    }

    private void OnDisable()
    {
        _inputs.Disable();
        _inputs.Gears.Gear1.performed -= GearAction;
        _inputs.Gears.Gear2.performed -= GearAction;
        _inputs.Gears.Gear3.performed -= GearAction;
        _inputs.Gears.Gear4.performed -= GearAction;
        _inputs.Gears.Reverse.performed -= Reverse;
    }

    private void GearAction(InputAction.CallbackContext context)
    {
        int gearValue = int.Parse(context.action.name.Replace("Gear", ""));
        float newMaxSpeed = gearValue * 5;

        if (Mathf.Abs(newMaxSpeed - _previousMaxSpeed) > 10)
        {
            StartCoroutine(GearboxFailureCorutine());
        }

        maxSpeed = newMaxSpeed;
        isInReverse = false;
        acceleration = 1000;

        _previousMaxSpeed = newMaxSpeed;
    }
    private void Reverse(InputAction.CallbackContext context)
    {
        if (maxSpeed <= 5)
        {
            isInReverse = true;
            acceleration = -1000;
            maxSpeed = 5;
        }
    }

    IEnumerator GearboxFailureCorutine()
    {
        Debug.Log("engine failure");
        engineWorking = false;
        restartUIScript.gameObject.SetActive(true);
        StartCoroutine(restartUIScript.ImageFill());

        yield return new WaitForSeconds(5);

        Debug.Log("engine running again");
        engineWorking = true;
        restartUIScript.gameObject.SetActive(false);
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
        if (engineWorking)
        {
            if (Input.GetMouseButton(0) && Input.GetMouseButton(1) && _onGround == true) //moving forward
            {
                rb.AddRelativeForce(Vector3.forward * acceleration * Time.deltaTime, ForceMode.Acceleration);
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

    }

    public void SpeedLimit()
    {
        Vector3 velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
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

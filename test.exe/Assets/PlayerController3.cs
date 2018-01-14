using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController3 : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;

    [SerializeField]
    private float jumpForce = 10f;


    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    Rigidbody rb;
    private PlayerMotor motor;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        motor = GetComponent<PlayerMotor>();       
    }

    void FixedUpdate()
    {
        //movement
        float _xMove = Input.GetAxisRaw("Horizontal");
        float _zMove = Input.GetAxisRaw("Vertical");

        Vector3 moveHor = transform.right * _xMove;
        Vector3 moveVer = transform.forward * _zMove;

        Vector3 _velocity = (moveHor + moveVer).normalized * speed;

        motor.Move(_velocity);

        float _yRot = Input.GetAxisRaw("Mouse X");
        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;
        motor.Rotate(_rotation);


        float _xRot = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRot * lookSensitivity;
        motor.RotateCamera(_cameraRotationX);


        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        
        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector3.up * jumpForce;
        }

//        motor.ApplyJump(_jumpForce);

    }
}

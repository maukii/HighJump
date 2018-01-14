using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FPSController : NetworkBehaviour
{
    CharacterController localPlayer;

    Transform mainCamera;

    public float speed = 2f;
    public float sensitivity = 2f;

    float moveFB;
    float moveLR;

    float rotX;
    float rotY;
	
	void Start ()
    {
        if(!isLocalPlayer)
        {
            Destroy(this);
            return;
        }

        localPlayer = GetComponent<CharacterController>();

        mainCamera = Camera.main.transform;
        MoveCamera();
	}

    void FixedUpdate ()
    {

        moveFB = Input.GetAxisRaw("Vertical") * speed;
        moveLR = Input.GetAxisRaw("Horizontal") * speed;

        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY -= Input.GetAxis("Mouse Y") * sensitivity;
        rotY = Mathf.Clamp(rotY, -60f, 60f);

        Vector3 movement = new Vector3(moveLR, 0, moveFB);
        transform.Rotate(-rotY, rotX, 0);
        transform.localRotation = Quaternion.Euler(rotY, 0, 0);

        movement = transform.rotation * movement;
        localPlayer.Move(movement * Time.deltaTime);

        MoveCamera();
    }

    void MoveCamera()
    {
        mainCamera.position = transform.position;
        mainCamera.rotation = localPlayer.transform.rotation;

    } 
}

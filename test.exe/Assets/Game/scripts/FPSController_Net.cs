using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FPSController_Net : NetworkBehaviour
{
    float speed = 2f;


    float cameraHeight = 0.5f;

    Rigidbody localRigidbody;
    Transform mainCamera;
    Vector3 cameraOffset;

    void Start()
    {
        if (!isLocalPlayer)
        {
            Destroy(this);
            return;
        }

        localRigidbody = GetComponent<Rigidbody>();
        cameraOffset = new Vector3(0f, cameraHeight, 0f);

        Cursor.lockState = CursorLockMode.Locked;

        mainCamera = Camera.main.transform;
        MoveCamera();
    }

    void FixedUpdate()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        if(Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        //movement
        //jump
        //mouse look
        MoveCamera();
    }

    void MoveCamera()
    {
        mainCamera.position = transform.position;
//        mainCamera.rotation = transform.rotation;
//        mainCamera.Translate(cameraOffset);
//        mainCamera.LookAt(transform);
    }
}

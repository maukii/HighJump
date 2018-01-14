using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MouseLook : NetworkBehaviour
{
    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 5f;
    public float smoothing = 2f;

    public GameObject player;

	// Use this for initialization
	void Start ()
    {

        if (!isLocalPlayer)
        {
            Destroy(this);
            return;
        }

//        player = this.transform.parent.gameObject;

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {

        var mb = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mb = Vector2.Scale(mb, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, mb.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mb.y, 1f / smoothing);
        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);

    }
}

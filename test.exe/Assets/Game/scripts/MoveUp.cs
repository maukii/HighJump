using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour {

    public int speed;


	void Update ()
    {
        moveUp();
    }

    void moveUp()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

}

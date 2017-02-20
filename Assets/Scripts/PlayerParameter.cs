using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParameter : MonoBehaviour {

    public bool isTeleport;
    public bool isTrigger;
    public bool isLanded;
    public GameObject teleport;
    public GameObject InputController;
    bool inverseGravity;
    float gravitySign;

    // Use this for initialization
    void Start () {
        isTeleport = false;
        isTrigger = false;
        isLanded = false;
        inverseGravity = false;
        gravitySign = -1.0f;
	}
	
	// Update is called once per frame
	void Update () {

        isTrigger = InputController.GetComponent<InputManager>().readyTeleport;
        if (isTeleport == true && isTrigger == true)
        {
            transform.position = teleport.transform.position;
            isTeleport = false;
            isTrigger = false;
        }
        
        inverseGravity = InputController.GetComponent<InputManager>().inverseGravity;
        if (inverseGravity == true && isLanded == true)
        {
            isLanded = false;
            inverseGravity = false;
            ReverseGravity();
        }
    }

    public void ReverseGravity()
    {
        gravitySign *= -1.0f;
        Physics.gravity = new Vector3(0, gravitySign * 9.81f, 0);  // reverser gravity
        if (gravitySign < 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(180, 180, 0);
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "floor")
        {
            isLanded = true;
        }
    }

}

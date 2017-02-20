using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalParameter : MonoBehaviour {

    public bool isCreated;
    public bool isTriggered;
    public GameObject InputController;

	// Use this for initialization
	void Start () {
        isCreated = true;
        isTriggered = false;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        // Keep reading from Input Manager is the portals are triggered
        isTriggered = InputController.GetComponent<InputManager>().showPortals;
        // If portals are triggered and are created, Render them, else disappear from the scene
        if (isTriggered == true && isCreated == true)
        {
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<SphereCollider>().enabled = true;
        }
        if (isTriggered == false || isCreated == false)
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
        }

    }

}

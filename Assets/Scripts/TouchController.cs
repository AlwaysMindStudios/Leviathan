using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {

    public OVRInput.Controller TController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = OVRInput.GetLocalControllerPosition(TController);
        transform.localRotation = OVRInput.GetLocalControllerRotation(TController);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public bool showPortals;
    public bool readyTeleport;
    public bool inverseGravity;

    // Use this for initialization
    void Start() {
        showPortals = false;
        readyTeleport = false;

    }

    // Update is called once per frame
    void Update() {
        OVRInput.Update(); // need to be called for checks below to work

        // If A or X button is pressed from Touch, showPortals is true, else is false
        if (OVRInput.Get(OVRInput.Button.One) || OVRInput.Get(OVRInput.Button.Three))
        {
            showPortals = true;
        }
        else
        {
            showPortals = false;
        }

        // If hand trigger is pressed from Touch, readyTeleport is true, else is false
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) || OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            readyTeleport = true;
        }
        else
        {
            readyTeleport = false;
        }

        // If B or Y button is pressed from Touch, inverse Gravity
        if (OVRInput.GetDown(OVRInput.Button.Two) || OVRInput.Get(OVRInput.Button.Four))
        {
            inverseGravity = true;
        }
        else
        {
            inverseGravity = false;
        }


        // Input Manager for Left Touch
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            print("LTouch_IndexTrigger pressed");
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick))
        {
            print("LTouch_Thumbstick pressed");
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickUp))
        {
            print("LTouch_ThumbstickUp pressed");
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickDown))
        {
            print("LTouch_ThumbstickDown pressed");
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickLeft))
        {
            print("LTouch_ThumbstickLeft pressed");
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickRight))
        {
            print("LTouch_ThumbstickRight pressed");
        }


        // Input Manager for Right Touch
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            print("RTouch_IndexTrigger pressed");
        }
        if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick))
        {
            print("RTouch_Thumbstick pressed");
        }
        if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstickUp))
        {
            print("RTouch_ThumbstickUp pressed");
        }
        if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstickDown))
        {
            print("RTouch_ThumbstickDown pressed");
        }
        if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstickLeft))
        {
            print("RTouch_ThumbstickLeft pressed");
        }
        if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstickRight))
        {
            print("RTouch_ThumbstickRight pressed");
        }
    }

}

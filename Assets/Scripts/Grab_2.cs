using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grab_2 : MonoBehaviour
{
    public OVRInput.Controller controller;

    private GameObject handLeft;
    private GameObject handRight;
    private Transform handLeftTransform;
    private Transform handRightTransform;
    private BoxCollider handLeftMeshCollider;
    private BoxCollider handRightMeshCollider;
    public bool colisionHands = false;
    private float leftHand;
    private float rightHand;

    public float grabRadius;
    public LayerMask grabMask;

    private GameObject grabbedObject;
    private bool grabbing;

    private RaycastHit[] hits;


    void Awake()
    {
        handLeft = GameObject.Find("LTouch");
        handRight = GameObject.Find("RTouch");
        handLeftTransform = handLeft.GetComponent<Transform>();
        handRightTransform = handRight.GetComponent<Transform>();
        handLeftMeshCollider = handLeft.GetComponentInChildren<BoxCollider>();
        handRightMeshCollider = handRight.GetComponentInChildren<BoxCollider>();

        // only make collisions with hands if checkbox is enabled
        if (colisionHands)
        {
            handLeftMeshCollider.enabled = true;
            handRightMeshCollider.enabled = true;
        }
        else {
            handLeftMeshCollider.enabled = false;
            handRightMeshCollider.enabled = false;
        }
    }

    void GrabOject()
    {

        grabbing = true;

        hits = Physics.SphereCastAll(
            transform.position,
            grabRadius,
            transform.forward,
            0f,
            grabMask
        );

        if (hits.Length > 0)
        {
            int closestHit = 0;
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].distance < hits[closestHit].distance)
                {
                    closestHit = i;
                }
            }

            grabbedObject = hits[closestHit].transform.gameObject;
            Debug.Log(grabbedObject.gameObject.name);
            grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
            

            if ((leftHand > 0) && (rightHand > 0))
            {

                if (colisionHands)
                {
                    handLeftMeshCollider.enabled = false;
                    handRightMeshCollider.enabled = false;
                }

                grabbedObject.transform.position = transform.position;
                grabbedObject.transform.rotation = transform.rotation;

            }
            else if (leftHand > 0)
            {

                if (colisionHands)
                {
                    handLeftMeshCollider.enabled = false;
                }

                grabbedObject.transform.position = handLeftTransform.position;
                grabbedObject.transform.rotation = handLeftTransform.rotation;
            }
            else if (rightHand > 0)
            { 

                if (colisionHands)
                {
                    handRightMeshCollider.enabled = false;
                }

                grabbedObject.transform.position = handRightTransform.position;
                grabbedObject.transform.rotation = handRightTransform.rotation;
            }

        }

    }

    void DropObject()
    {
        grabbing = false;

        if (grabbedObject != null)
        {
            grabbedObject.transform.parent = null;
            grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            grabbedObject.GetComponent<Rigidbody>().velocity = OVRInput.GetLocalControllerVelocity(controller) * -1;
            grabbedObject.GetComponent<Rigidbody>().angularVelocity = OVRInput.GetLocalControllerAngularVelocity(controller).eulerAngles * -1;
                                                                                                                                              
            grabbedObject = null;

            if (colisionHands)
            {
                handLeftMeshCollider.enabled = true;
                handRightMeshCollider.enabled = true;
            }
        }
    }

    void Update()
    {
        leftHand = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger);
        rightHand = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);

        if (grabbing != true && (leftHand + rightHand) > 0)
        {
            GrabOject();
        }
        else
        {
            DropObject();
        }
    }
}
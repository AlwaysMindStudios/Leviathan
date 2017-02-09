using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour {

    public GameObject player;
    public Camera cameraFacing;
    private Vector3 originalScale;


	// Use this for initialization
	void Start () {
        originalScale = transform.localScale * 0.1f;
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        float distance;
        if (Physics.Raycast (new Ray (cameraFacing.transform.position, cameraFacing.transform.rotation * Vector3.forward), out hit))
        {
            distance = hit.distance;
        }
        else
        {
            distance = cameraFacing.farClipPlane * 0.95f;
        }
        try
        {
            if (hit.collider.name == "portal")
            {
                if (hit.collider.gameObject.GetComponent<PortalParameter>().isCreated == true && hit.collider.gameObject.GetComponent<PortalParameter>().isTriggered == true)
                {
                    //Debug.Log(hit.collider.gameObject.name);
                    player.GetComponent<PlayerParameter>().teleport = hit.collider.gameObject;
                    player.GetComponent<PlayerParameter>().isTeleport = true;
                }
            }
            else
            {
                player.GetComponent<PlayerParameter>().teleport = null;
                player.GetComponent<PlayerParameter>().isTeleport = false;
            }
        }
        catch { }



        transform.position = cameraFacing.transform.position + cameraFacing.transform.rotation * Vector3.forward * (distance - 0.1f) ;
        transform.LookAt(cameraFacing.transform.position);
        transform.Rotate(0.0f, 180.0f, 0.0f);
        if (distance < 10.0f)
        {
            distance *= 1 + 5 * Mathf.Exp(-distance);
        }
        transform.localScale = originalScale * distance;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    [Header("Hold Settings")]
    //Location of the player camera
    public Transform cameraLoc;
    //Location that the object will be held at relative to the player
    public Transform holdLoc;
    //Maximum distance that the player can pick an object up from
    public float holdDistance;
    //Strength the object will shoot toward the player
    public float pickUpForce;

    //Information about the gameobject that is picked up
    private GameObject pickedUpObject;
    private Rigidbody pickedUpRb;

    [Header("Throw Settings")]
    //How hard the object will be thrown
    public float throwStrength;


    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(pickedUpObject == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(cameraLoc.position, cameraLoc.TransformDirection(Vector3.forward), out hit, holdDistance))
                {
                    if(hit.transform.gameObject.tag == "Carryable")
                        pickupObject(hit.transform.gameObject);
                }
            }
            else
            {
                throwObject();
            }
        }
        if(pickedUpObject != null)
        {
            moveObject();
        }
    }

    void moveObject()
    {
        if(Vector3.Distance(pickedUpObject.transform.position, holdLoc.position) > 0.1f)
        {
            pickedUpObject.transform.position = Vector3.MoveTowards(
                                                                    pickedUpObject.transform.position, 
                                                                    holdLoc.position, 
                                                                    pickUpForce
                                                );
        }
    }

    void pickupObject(GameObject pickUpObject) 
    {
        //Makes sure that there is a rigidbody
        if (pickUpObject.GetComponent<Rigidbody>())
        {
            pickedUpRb = pickUpObject.GetComponent<Rigidbody>();
            pickedUpRb.useGravity = false;
            pickedUpRb.drag = 10;
            pickedUpRb.constraints = RigidbodyConstraints.FreezeRotation;

            pickedUpRb.transform.parent = holdLoc;
            pickedUpObject = pickUpObject;
            pickedUpObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    void throwObject()
    {
        //Adds Physics Back
        pickedUpRb.useGravity = true;
        pickedUpRb.drag = 1;
        pickedUpRb.constraints = RigidbodyConstraints.None;

        //Throws Object
        pickedUpRb.AddForce(cameraLoc.TransformDirection(Vector3.forward) * throwStrength, ForceMode.Impulse);
        pickedUpObject.GetComponent<BoxCollider>().enabled = true;

        //Resets the references
        pickedUpRb.transform.parent = null;
        pickedUpObject = null;
        pickedUpRb = null;
    }
}

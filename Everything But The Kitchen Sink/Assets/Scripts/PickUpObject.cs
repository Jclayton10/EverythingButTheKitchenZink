using Photon.Pun;
using UnityEngine;

public class PickUpObject : MonoBehaviourPun
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

    //Game Object that is being picked up
    private GameObject pickedUpObject;
    //Rigidbody of the object that is being picked up
    private Rigidbody pickedUpRb;

    [Header("Throw Settings")]
    //How hard the object will be thrown
    public float throwStrength;

    /// <summary>
    /// Big-O: O(1)
    /// 
    /// If the player clicks the left mouse button, it will pick up an object if it doesn't currently have one. Or, it will throw the object.
    /// If the left mouse button isn't clicked, it will update the item location
    /// </summary>
    public void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (pickedUpObject == null)
                {
                    RaycastHit hit;
                    
                    if (Physics.Raycast(cameraLoc.position, cameraLoc.TransformDirection(Vector3.forward), out hit, holdDistance))
                    {
                        if (hit.collider.gameObject.tag == "Door" && GetComponent<PlayerStats>().score >= GameObject.Find("Global Stats").GetComponent<GlobalStats>().costForRoom)
                        {
                            GetComponent<PlayerStats>().score -= GameObject.Find("Global Stats").GetComponent<GlobalStats>().costForRoom;
                            hit.collider.transform.parent.parent.parent.GetComponent<UnlockRoom>().unlock();
                            
                            return;
                        }
                        if (hit.transform.gameObject.tag == "Sink")
                        {
                            Debug.Log("Clicked On Sink");
                            hit.transform.GetComponent<Sink>().Teleport();
                        }
                        if (hit.transform.gameObject.tag == "Carryable")
                        {
                            hit.transform.gameObject.GetComponent<BreakableObject>().player = gameObject;
                            pickupObject(hit.transform.gameObject);
                        }
                    }
                }
                else
                {
                    throwObject();
                }
            }
            if (pickedUpObject != null)
            {
                moveObject();
            }
        }
    }

    /// <summary>
    /// Big-O: O(1)
    /// 
    /// Updates the object to the location it should be held at
    /// </summary>
    void moveObject()
    {
        //Checks if the gameObject is within a certain radius
        pickedUpObject.transform.position = holdLoc.transform.position;
        pickedUpObject.transform.rotation = holdLoc.transform.rotation;
    }

    /// <summary>
    /// Big-O: O(1)
    /// 
    /// Picks up an object. Sets the pickedUpObject and pickedUpRb variables
    /// </summary>
    /// <param name="pickUpObject">Object to be picked up</param>
    void pickupObject(GameObject pickUpObject)
    {
        pickUpObject.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);
        //Makes sure that there is a rigidbody
        if (pickUpObject.GetComponent<Rigidbody>())
        {
            //Sets the pickedUpRb values. It also turns of gravity for the object
            pickedUpRb = pickUpObject.GetComponent<Rigidbody>();
            pickedUpRb.useGravity = false;

            //Sets the pickedUpObject value. It also disables the collider for the object
            pickedUpObject = pickUpObject;
            pickedUpObject.GetComponent<Collider>().enabled = false;
        }
    }

    /// <summary>
    /// Big-O: O(1)
    /// 
    /// Throws GameObject at throwStrength
    /// </summary>
    void throwObject()
    {
        //Adds Gravity Back
        pickedUpRb.useGravity = true;

        //Throws Object
        pickedUpRb.AddForce(cameraLoc.TransformDirection(Vector3.forward) * throwStrength, ForceMode.Impulse);
        pickedUpObject.GetComponent<Collider>().enabled = true;

        //Resets the references
        pickedUpObject = null;
        pickedUpRb = null;
    }


}

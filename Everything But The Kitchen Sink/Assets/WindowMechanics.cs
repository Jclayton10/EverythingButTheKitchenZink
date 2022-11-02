using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowMechanics : MonoBehaviour
{
    public GameObject brokenWindow;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Carryable")
        {

            brokenWindow.SetActive(true);
            foreach(Rigidbody child in brokenWindow.GetComponentsInChildren<Rigidbody>())
            {
                child.AddExplosionForce(500f, collision.transform.position, 1f);
            }
            Destroy(gameObject);
        }
    }
}

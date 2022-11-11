using UnityEngine;

public class WindowMechanics : MonoBehaviour
{
    //Game Object of the Broken Window GameObject
    public GameObject brokenWindow;

    /// <summary>
    /// Big-O: O(n)
    /// 
    /// Swaps to broken window object then adds an explosion to blow up the window
    /// </summary>
    /// <param name="collision">Game Object colliding with the window</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Carryable")
        {
            //Turns on the broken window
            brokenWindow.SetActive(true);

            //Adds an explosion to each part of the window
            foreach (Rigidbody child in brokenWindow.GetComponentsInChildren<Rigidbody>())
            {
                child.AddExplosionForce(500f, collision.transform.position, 1f);
            }
            //Destroys unbroken window
            Destroy(gameObject);
        }
    }
}

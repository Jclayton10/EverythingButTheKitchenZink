using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleSpawn : MonoBehaviour
{
    public Transform topCorner;
    public Transform bottomCorner;

    public void Spawn(GameObject enemyToSpawn)
    {
        GameObject.Instantiate(enemyToSpawn, new Vector3(Random.Range(topCorner.position.x, bottomCorner.position.x), transform.position.y, Random.Range(topCorner.position.z, bottomCorner.position.z)), Quaternion.Euler(0, 0, 0));
    }
    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(topCorner.position, 0.1f);
        Gizmos.DrawSphere(bottomCorner.position, 0.1f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleSpawn : MonoBehaviour
{
    public GameObject spawnPrefab;
    public Transform topCorner;
    public Transform bottomCorner;
    public int spawnAmt;
    public bool spawn;

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            for (int i = 0; i < spawnAmt; i++)
            {
                GameObject.Instantiate(spawnPrefab, new Vector3(Random.Range(topCorner.position.x, bottomCorner.position.x), transform.position.y, Random.Range(topCorner.position.z, bottomCorner.position.z)), Quaternion.Euler(0, 0, 0));
            }
            spawn = !spawn;
        }
    }
    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(topCorner.position, 0.1f);
        Gizmos.DrawSphere(bottomCorner.position, 0.1f);
    }
}

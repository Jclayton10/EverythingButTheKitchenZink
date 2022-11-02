using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawning : MonoBehaviour
{
    public GameObject spawnPrefab;
    public float spawnRadius;
    public int spawnAmt;
    public bool spawn;

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            for(int i = 0; i < spawnAmt; i++)
            {
                Vector2 locRelativeToCenter = Random.insideUnitCircle.normalized * spawnRadius;
                GameObject.Instantiate(spawnPrefab, transform.position + new Vector3(locRelativeToCenter.x, 0, locRelativeToCenter.y), Quaternion.Euler(0,0,0));
            }
            spawn = !spawn;
        }
    }
    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}

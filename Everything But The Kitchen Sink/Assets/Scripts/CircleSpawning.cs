using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawning : MonoBehaviour
{
    public float spawnRadius;

    // Update is called once per frame
    public void Spawn(GameObject enemyToSpawn)
    {
        Vector2 locRelativeToCenter = Random.insideUnitCircle.normalized * spawnRadius;
        GameObject.Instantiate(enemyToSpawn, transform.position + new Vector3(locRelativeToCenter.x, 0, locRelativeToCenter.y), Quaternion.Euler(0, 0, 0));
    }
    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}

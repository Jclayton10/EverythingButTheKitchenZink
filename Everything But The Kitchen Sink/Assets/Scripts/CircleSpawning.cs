using UnityEngine;

public class CircleSpawning : MonoBehaviour
{
    //Radius around game object that enemies can spawn within
    public float spawnRadius;

    /// <summary>
    /// Spawn the enemy within the radius of the gameObject.
    /// </summary>
    /// <param name="enemyToSpawn">Prefab of enemytype to spawn</param>
    public void Spawn(GameObject enemyToSpawn)
    {
        //Gets a random location within the circle of radius spawnRadius
        Vector2 locRelativeToCenter = Random.insideUnitCircle.normalized * spawnRadius;
        //Spawns the enemy
        GameObject.Instantiate(enemyToSpawn, transform.position + new Vector3(locRelativeToCenter.x, 0, locRelativeToCenter.y), Quaternion.Euler(0, 0, 0));
    }
    /// <summary>
    /// Draws a wiresphere of radius spawnRadius in the scene view. Only used to aid in placing spawnAreas
    /// </summary>
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}

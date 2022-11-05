using UnityEngine;

public class RectangleSpawn : MonoBehaviour
{
    //Top Left Corner of the Rectangle Spawner
    public Transform topCorner;
    //Bottom Right Corner of the Rectangle Spawner
    public Transform bottomCorner;

    /// <summary>
    /// Big-O: O(1)
    /// 
    /// Spawn the enemy within the box of the GameObject
    /// </summary>
    /// <param name="enemyToSpawn">Prefab of enemytype to spawn</param>
    public void Spawn(GameObject enemyToSpawn)
    {
        GameObject.Instantiate(enemyToSpawn, new Vector3(Random.Range(topCorner.position.x, bottomCorner.position.x), transform.position.y, Random.Range(topCorner.position.z, bottomCorner.position.z)), Quaternion.Euler(0, 0, 0));
    }
}

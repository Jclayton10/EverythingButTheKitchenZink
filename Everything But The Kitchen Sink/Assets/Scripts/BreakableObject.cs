using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    //Key that the item will be calling from
    public int itemKey;

    //Health the object has at spawn
    [Range(1, 10)]
    public int maxHealth;
    //Health the object has currently
    public float currentHealth;

    //Minimum speed that it must be travelling before it takes damage
    [Range(0, 1)]
    public float minSpeed;

    //Speed the object shrink
    public float shrinkSpeed;

    //Amt of damage it deals to enemies
    public float damage;

    //Rigidbody of GameObject
    private Rigidbody rb;

    public GameObject player;

    /// <summary>
    /// Big-O: O(1)
    /// 
    /// Start function. Sets the rb variable to the gameObjects rigidbody component and sets currentHealth to maxHealth
    /// </summary>
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        Vector3 values = GameObject.Find("Stats").GetComponent<ItemStats>().itemValues[itemKey];

        rb.mass = values.x;
        damage = values.y;
        maxHealth = (int) values.z;
        currentHealth = maxHealth;
    }

    /// <summary>
    /// Big-O: O(1)
    /// 
    /// Checks if currentHealth is equal to or less than 0. If it is, it will call the shrink class.
    /// </summary>
    private void Update()
    {
        if (currentHealth <= 0)
        {
            Shrink();
        }
    }

    /// <summary>
    /// Big-O: O(1)
    /// 
    /// Lowers health of gameObject when it collides with another game object with a tag of either Enemy or Carryable
    /// </summary>
    /// <param name="collision">Game Object this Game Object collides with</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("true");
            if (rb.velocity.magnitude > minSpeed)
            {
                Debug.Log(player);
                TakeDamage(2);
                collision.transform.root.Find("Animation").GetComponent<EnemyStats>().killer = player;
            }
        }
    }

    /// <summary>
    /// Big-O: O(1)
    /// 
    /// Shrink will cause the item to grow smaller. When the gameObject reaches a scale of 0, it will destroy the gameObject
    /// </summary>
    private void Shrink()
    {
        transform.localScale -= new Vector3(shrinkSpeed, shrinkSpeed, shrinkSpeed) * Time.deltaTime;
        if (transform.localScale.x <= 0 || transform.localScale.y <= 0 || transform.localScale.z <= 0)
            Destroy(gameObject);
    }

    /// <summary>
    /// Big-O: O(1)
    /// 
    /// Lowers the currentHealth value by the inputted value
    /// </summary>
    /// <param name="dmg">Amount of Damage To Deal</param>
    private void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
    }
}

using UnityEngine;
public class EnemyStats : MonoBehaviour
{
    //Maximum Health / Health is starts with
    public float MaxHealth;
    //Current Health of Enemy
    public float currentHealth;

    //Amt of damage it deals to players
    public float playerDmg;
    public float shrinkSpeed;

    //Minimum speed an object must be moving to damage it
    public float minSpeed;
    //Rigidbody of Object Colliding with it
    private Rigidbody rb;

    private void Start()
    {
        currentHealth = MaxHealth;
    }
    private void Update()
    {
        if (currentHealth <= 0)
            Shrink();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>())
        {
            rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb.velocity.magnitude > minSpeed)
            {
                if (collision.gameObject.tag == "Carryable")
                {
                    TakeDamage(collision.gameObject.GetComponent<BreakableObject>().damage);
                }
            }
        }
    }

    private void Shrink()
    {
        transform.localScale -= new Vector3(shrinkSpeed, shrinkSpeed, shrinkSpeed) * Time.deltaTime;
        if (transform.localScale.magnitude < 0.1f)
            Destroy(gameObject);
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
    }
}

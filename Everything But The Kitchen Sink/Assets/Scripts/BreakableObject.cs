using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    [Range(1, 10)]
    public int maxHealth;
    public float currentHealth;

    //Minimum speed that it must be travelling before it takes damage
    [Range(0, 1)]
    public float minSpeed;

    public float shrinkSpeed;

    //Amt of damage it deals to enemies
    public float damage;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            Shrink();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (rb.velocity.magnitude > minSpeed)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                TakeDamage(2);
            }
            else if (collision.gameObject.tag != "Carryable")
            {
                TakeDamage(1);
            }
        }
    }

    private void Shrink()
    {
        transform.localScale -= new Vector3(shrinkSpeed, shrinkSpeed, shrinkSpeed) * Time.deltaTime;
        if (transform.localScale.magnitude < 0.1f)
            Destroy(gameObject);
    }

    private void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
    }
}

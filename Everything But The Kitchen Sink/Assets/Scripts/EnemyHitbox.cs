using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
	/// <summary>
	/// Big-O: O(1)
	/// 
	/// Checks if the zombie is hit by a carryable object. Then it deals damage to the enemy
	/// </summary>
	/// <param name="collision">Game Object the zombie is being by</param>
	Rigidbody rb;
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Carryable")
		{
			rb = collision.gameObject.GetComponent<Rigidbody>();
			if (rb.velocity.magnitude > 0.1f)
			{
				if (collision.gameObject.GetComponent<BreakableObject>())
					transform.root.Find("Animation").GetComponent<EnemyStats>().TakeDamage(collision.gameObject.GetComponent<BreakableObject>().damage);
			}
		}
	}
}

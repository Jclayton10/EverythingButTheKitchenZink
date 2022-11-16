using Photon.Pun;
using UnityEngine;
public class EnemyStats : MonoBehaviourPun
{
	//Maximum Health / Health is starts with
	public float MaxHealth;
	//Current Health of Enemy
	public float currentHealth;

	//Amt of damage it deals to players
	public float playerDmg;
	//Speed the enemy shrinks at when health drops low
	public float shrinkSpeed;

	//Minimum speed an object must be moving to damage it
	public float minSpeed;
	//Rigidbody of Object Colliding with it
	private Rigidbody rb;

	//Player who killed the zombie
	public GameObject killer;

	//Points gained when it's killed
	public int KillPoints;

	/// <summary>
	/// Big-O: O(1)
	/// 
	/// Sets the current health value to the spawn value
	/// </summary>
	private void Start()
	{
		currentHealth = MaxHealth;
	}
	/// <summary>
	/// Big-O: O(1)
	/// 
	/// If health is below or equal to 0, run the shrink function
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
	/// Checks if the zombie is hit by a carryable object. Then it deals damage to the enemy
	/// </summary>
	/// <param name="collision">Game Object the zombie is being by</param>

	/// <summary>
	/// Big-O: O(1)
	/// 
	/// Shrink will cause the item to grow smaller. When the gameObject reaches a scale of 0, it will destroy the gameObject
	/// </summary>
	private void Shrink()
	{
		transform.localScale -= new Vector3(shrinkSpeed, shrinkSpeed, shrinkSpeed) * Time.deltaTime;
		if (transform.localScale.y < 0.1f)
		{
			--GameObject.Find("Enemy AI").GetComponent<EnemyAIInitialization>().currentAliveZombies;
			if(killer)
				killer.GetComponent<PlayerScore>().IncreaseScore(KillPoints);
			Destroy(transform.parent.gameObject);
		}
	}

	/// <summary>
	/// Big-O: O(1)
	/// 
	/// Lowers the currentHealth value by the inputted value
	/// </summary>
	/// <param name="dmg">Amount of Damage To Deal</param>
	[PunRPC]
	public void TakeDamage(float dmg)
	{
		currentHealth -= dmg;
		PhotonView.Get(this).RPC("TakeDamage", RpcTarget.Others, dmg);
	}
}

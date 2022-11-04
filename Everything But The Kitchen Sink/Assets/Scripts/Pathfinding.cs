using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    //Pathfinding component
    public NavMeshAgent navMeshAgent;
    //Location of player
    public Transform playerLoc;

    public bool RunAI = false;

    /// <summary>
    /// Initializes the navMeshAgent component and the playerLoc variables
    /// </summary>
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerLoc = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    /// <summary>
    /// Sets the pathfinding goal to the player's location
    /// </summary>
    void Update()
    {
        if (RunAI)
            navMeshAgent.SetDestination(playerLoc.position);
    }
}

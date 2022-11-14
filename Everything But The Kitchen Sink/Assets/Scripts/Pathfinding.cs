using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviourPunCallbacks
{
    //Pathfinding component
    public NavMeshAgent navMeshAgent;
    //Location of player
    public Transform playerLoc;

    public List<Transform> allPlayers;

    public bool RunAI = false;

    /// <summary>
    /// Big-O: O(1)
    /// 
    /// Initializes the navMeshAgent component and the playerLoc variables
    /// </summary>
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (GameObject.Find("Enemy AI").activeSelf)
            {
                navMeshAgent = GetComponent<NavMeshAgent>();
                foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
                {
                    allPlayers.Add(player.transform);
                }
            }
        }
    }

    /// <summary>
    /// Big-O: O(1)
    /// 
    /// Sets the pathfinding goal to the player's location
    /// </summary>
    void Update()
    {
        if (PhotonNetwork.IsMasterClient && RunAI)
        {
            float shortestDistance;
            int playerVal;

            navMeshAgent.SetDestination(allPlayers[0].position);
            shortestDistance = navMeshAgent.remainingDistance;
            playerVal = 0;

            for (int i = 1; i < allPlayers.Count; ++i)
            {
                navMeshAgent.SetDestination(allPlayers[i].position);
                if (shortestDistance > navMeshAgent.remainingDistance)
                {
                    shortestDistance = navMeshAgent.remainingDistance;
                    playerVal = i;
                }
            }

            //This gets the closest player
            navMeshAgent.SetDestination(allPlayers[playerVal].position);
        }
    }
}

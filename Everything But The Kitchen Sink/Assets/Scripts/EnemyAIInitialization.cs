using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIInitialization : MonoBehaviour
{
    //A list of all enemySpawner gameObjects
    public List<GameObject> enemySpawners = new List<GameObject>();
    //Enemy Prefab to be spawned
    public GameObject chooseEnemy;
    //Number of Currently Alive Zombies
    public int currentAliveZombies;
    //Number of Zombies to be spawned in the wave
    public int waveSpawnAmt;

    //Number of seconds between waves
    public int timeBetweenWaves = 5;
    //Time that has so far elapsed between waves
    public float timeElapsed = 0;
    //Bool to check if it is currently between waves
    public bool betweenWaves = true;

    /// <summary>
    /// Big-O: O(1)
    /// 
    /// Sets timeElapsed to timeBetweenWaves. Used for initialization of scene
    /// </summary>
    public void Start()
    {
        timeElapsed = timeBetweenWaves;
    }

    /// <summary>
    /// Big-O: O(1)
    /// 
    /// Controls logic behind whether zombies should be spawned
    /// </summary>
    void Update()
    {
        if (currentAliveZombies == 0 && betweenWaves == false)
        {
            timeElapsed = timeBetweenWaves;
            betweenWaves = true;
        }
        if(timeElapsed < 0 && betweenWaves == true)
        {
            SpawnWave(waveSpawnAmt);
            betweenWaves = false;
            timeElapsed = 0;
        }
        if(timeElapsed > 0)
        {
            timeElapsed -= Time.deltaTime;
        }
    }

    /// <summary>
    /// Big-O: O(n)
    /// 
    /// Spawns a new wave of Zombies
    /// </summary>
    /// <param name="numOfZombs">Number of Zombies to be spawned</param>
    public void SpawnWave(int numOfZombs)
    {
        //Sets the number of currently alive zombies
        currentAliveZombies = numOfZombs;
        //Spawns the zombies
        for(int i = 0; i<numOfZombs; i++)
        {
            //Gets a spawner to spawn the zombie at
            GameObject chosenSpawner = enemySpawners[Random.Range(0, enemySpawners.Count - 1)];
            try
            {
                if (chosenSpawner.GetComponent<RectangleSpawn>())
                {
                    //Spawns zombie
                    chosenSpawner.GetComponent<RectangleSpawn>().Spawn(chooseEnemy);
                }
            }
            catch (UnityException)
            {
                Debug.Log(chosenSpawner.transform.parent.name);
            }
        }
    }
}

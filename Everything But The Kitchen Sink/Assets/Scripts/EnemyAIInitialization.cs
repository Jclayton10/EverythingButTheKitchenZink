using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIInitialization : MonoBehaviour
{
    public List<GameObject> enemySpawners = new List<GameObject>();
    public GameObject chooseEnemy;
    //Number of Currently Alive Zombies
    public int currentAliveZombies;
    public int waveSpawnAmt;

    //Number of seconds between waves
    public int timeBetweenWaves = 5;
    public float timeElapsed = 0;
    public bool betweenWaves = true;

    // Start is called before the first frame update
    public void Start()
    {
        timeElapsed = timeBetweenWaves;
    }

    // Update is called once per frame
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

    public void SpawnWave(int numOfZombs)
    {
        currentAliveZombies = numOfZombs;
        for(int i = 0; i<numOfZombs; i++)
        {
            GameObject chosenSpawner = enemySpawners[Random.Range(0, enemySpawners.Count - 1)];
            try
            {
                if (chosenSpawner.GetComponent<RectangleSpawn>())
                {
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

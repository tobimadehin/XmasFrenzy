using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Public
    public Enemy ememy;
    public SpawnPoint[] spawnPoints;

    //Private
    private float lastTimeUpdate;
    [SerializeField] private CustomUtilities utilities;


    void Update()
    {
        Spawn();
        TimerState();
        CanSpawn();
    }

    private bool TimerState()
    {
        bool timerState = false;

        if (Time.time - lastTimeUpdate > 1)
        {
            timerState = true;
            print("Can spawn");
            lastTimeUpdate = Time.time;
        }

        return timerState;
    }

    private void Spawn()
    {
        if (TimerState() && CanSpawn())
        {
            NextSpawnLocation();
            Instantiate(ememy.gameObject, NextSpawnLocation().position, NextSpawnLocation().rotation);
            print("Spawned Player!");
            TimerState().Equals(false);
        }
    }

    private bool CanSpawn()
    {
        bool canSpawn = false;

        if (utilities.EnemyCount() < 10)
        {
            canSpawn = true;
        }

        else
        {
            canSpawn = false;
        }

        return canSpawn;
    }

    private Transform NextSpawnLocation()
    {
        Transform nextSpawnLocation = null;
        int randomInt;
        int numberOfSpawnPoints = spawnPoints.Length;

        randomInt = Random.Range(0, numberOfSpawnPoints);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            nextSpawnLocation = spawnPoints[randomInt].transform;
        }

        print("The random number is " + randomInt);

        return nextSpawnLocation;
    }
}

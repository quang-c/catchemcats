using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catManager : MonoBehaviour
{

    public GameObject cat;
    public Transform[] spawnPoints;
    private int numberOfCats;
    private int randomSpawn;
    public float obstacleCheckRadius = 3f;
    public int maxSpawnAttemptsPerObstacle = 10;


    void Awake()
    {
        numberOfCats = 8;
        Spawn();
    }


    void Update()
    {

    }

    void Spawn()
    {


        for (int spawnPointIndex = 0; spawnPointIndex < numberOfCats; spawnPointIndex++)
        {


            bool validPosition = false;
            int spawnAttempts = 0;


            // While we don't have a valid position 
            //  and we haven't tried spawning this obstable too many times
            while (!validPosition && spawnAttempts < maxSpawnAttemptsPerObstacle)
            {
                // Increase our spawn attempts
                spawnAttempts++;

                // Pick a random position
                randomSpawn = Random.Range(0, spawnPoints.Length);

                // This position is valid until proven invalid
                validPosition = true;

                // Collect all colliders within our Obstacle Check Radius
                Collider[] colliders = Physics.OverlapSphere(spawnPoints[randomSpawn].position, obstacleCheckRadius);

                // Go through each collider collected
                foreach (Collider col in colliders)
                {
                    // If this collider is tagged "Obstacle"
                    if (col.tag == "Kitty")
                    {
                        // Then this position is not a valid spawn position
                        validPosition = false;
                    }
                }

                if (validPosition)
                {
                    Instantiate(cat, spawnPoints[randomSpawn].position, spawnPoints[randomSpawn].rotation);
                }
            }
        }
    }
}

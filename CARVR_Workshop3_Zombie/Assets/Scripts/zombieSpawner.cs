using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject zombieGO;

    [SerializeField]
    private GameObject player;

    //
    [Header("Spawning Mechanism")]
    public float spawnBeforeStart = 5.0f;

    public float spawnInterval = 5.0f;

    public float spawnRadius = 20.0f;

    public bool runSpawn = true;

    [Header("Max Number of Zombies")]
    public int maxZombies = 10;



    private static int zombieCount = 0; // Have users add a limit to the zombie spawner and make it slower
    


    private void Update()
    {
        if (zombieCount < maxZombies && runSpawn)
        {
            Debug.Log("Started spawning.");
            InvokeRepeating("ZombieSpawn", spawnBeforeStart, spawnInterval);
            runSpawn = false;
        }
        if (zombieCount >= maxZombies && runSpawn == false)
        {
            Debug.Log("Spawning has stopped.");
            CancelInvoke("ZombieSpawn");
            runSpawn = true;
        }
    }
    
    void ZombieSpawn()
	{
	        // Zombie Spawning Point is a point in a circle around the player of radius 10.
	        float angle = Random.Range(0f, Mathf.PI * 2);
	        float zombieX = Mathf.Sin(angle) * spawnRadius;
	        float zombieZ = Mathf.Cos(angle) * spawnRadius;

	        // Possible locations for the zombie to spawn
	        Vector3 zombieSpawnPoint = new Vector3(player.transform.position.x + zombieX, 0.0f, player.transform.position.z + zombieZ);
	        Vector3 zombieSpawnPointZero = Vector3.zero;

	        // Zombie spawned
	        Instantiate(zombieGO, zombieSpawnPoint, Quaternion.identity);

            // Add a Zombie enemy to the count.
            print(Time.time);
            zombieCount++;
            Debug.Log("Spawned " + zombieCount + " zombies.");
        
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawn = 3;
    [SerializeField] int maxEnemies = 3;
    [SerializeField] Transform[] spawnSpots = new Transform[0];
    [SerializeField] GameObject[] enemies = new GameObject[0];

    // Start is called before the first frame update
    void Start()
    {
            StartCoroutine(RepeatedlySpawnEnemies());      
    }

    IEnumerator RepeatedlySpawnEnemies() {
        while (transform.childCount -1 < maxEnemies) // -1 is for always have a SpawnSpots.
        {
            GameObject spawned = Instantiate(enemies[0], spawnSpots[0].position, Quaternion.identity);
            spawned.transform.SetParent(transform);
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
    }
}

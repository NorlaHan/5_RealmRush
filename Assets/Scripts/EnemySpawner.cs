using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawn = 3;
    [SerializeField] int maxEnemies = 3;
    [SerializeField] Transform[] spawnSpots = new Transform[0];
    [SerializeField] GameObject[] enemies = new GameObject[0];

    [SerializeField] PlayerHealth playerHealth;

    [SerializeField] AudioClip spawnEnemySFX;

    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindObjectOfType<PlayerHealth>();
        StartCoroutine(RepeatedlySpawnEnemies());
    }

    IEnumerator RepeatedlySpawnEnemies() {
        while (transform.childCount -1 < maxEnemies) // -1 is for always have a SpawnSpots.
        {
            myAudioSource = GetComponent<AudioSource>();
            myAudioSource.PlayOneShot(spawnEnemySFX);

            GameObject spawned = Instantiate(enemies[0], spawnSpots[0].position, Quaternion.identity);
            spawned.transform.SetParent(transform);

            playerHealth.GetScore(1);
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
    }
}

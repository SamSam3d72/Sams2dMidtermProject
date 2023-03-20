using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefabs; // An array of prefabs for each of the items
    public float spawnInterval = 2f; // The time interval between spawns
    public float spawnHeight = 10f; // The height at which the items will spawn
    public float spawnRadius = 5f; // The radius within which the items can spawn
    public Transform spawnStart; // The start position for spawning items
    public Transform spawnEnd; // The end position for spawning items

    private void Start()
    {
        // Start spawning items after a random delay
        InvokeRepeating("SpawnItem", Random.Range(0f, spawnInterval), spawnInterval);
    }

    private void SpawnItem()
    {
        // Randomly choose an item to spawn from the itemPrefabs array
        GameObject itemPrefab = itemPrefabs[Random.Range(0, itemPrefabs.Length)];

        // Randomly choose a spawn position within the spawnRadius
        float spawnX = Random.Range(spawnStart.position.x, spawnEnd.position.x);
        Vector3 spawnPos = new Vector3(spawnX, spawnHeight, 0f);

        // Spawn the item at the chosen position
        Instantiate(itemPrefab, spawnPos, Quaternion.identity);
    }
}

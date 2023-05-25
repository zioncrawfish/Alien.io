using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] alienPrefabs;
    public GameObject alien2Prefab;

    public int initialAlienCount = 60;
    public float spawnInterval = 1f;
    public int maxAlienCount = 175;
    public float minSpawnDistance = 50f;
    public float maxSpawnDistance = 150f;
    public float separationDistance = 10f;
    public int alien2SpawnInterval = 20;

    private Transform playerTransform;
    private List<GameObject> activeAliens = new List<GameObject>();
    private int alienCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player")?.transform;

        SpawnInitialAliens();
        StartCoroutine(SpawnAliens());
    }

    private void SpawnInitialAliens()
    {
        for (int i = 0; i < initialAlienCount; i++)
        {
            if (alienCounter < alien2SpawnInterval)
            {
                SpawnAlien(alienPrefabs);
            }
            else
            {
                SpawnAlien(alien2Prefab);
                alienCounter = 0;
            }
        }
    }

    private IEnumerator SpawnAliens()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (activeAliens.Count < maxAlienCount)
            {
                if (alienCounter < alien2SpawnInterval)
                {
                    SpawnAlien(alienPrefabs);
                }
                else
                {
                    SpawnAlien(alien2Prefab);
                    alienCounter = 0;
                }
            }
        }
    }

    private void SpawnAlien(GameObject[] prefabs)
    {
        Vector2 spawnPosition = GetRandomSpawnPosition();
        GameObject alienPrefab = GetRandomAlienPrefab(prefabs);

        GameObject alienInstance = Instantiate(alienPrefab, spawnPosition, Quaternion.identity);
        activeAliens.Add(alienInstance);
        alienCounter++;
    }

    private void SpawnAlien(GameObject prefab)
    {
        Vector2 spawnPosition = GetRandomSpawnPosition();

        GameObject alienInstance = Instantiate(prefab, spawnPosition, Quaternion.identity);
        activeAliens.Add(alienInstance);
        alienCounter++;
    }

    private Vector2 GetRandomSpawnPosition()
    {
        if (playerTransform == null)
        {
            Debug.LogError("Player transform not found.");
            return Vector2.zero;
        }

        Vector2 playerPosition = playerTransform.position;
        float randomAngle = Random.Range(0f, 2f * Mathf.PI);
        float randomDistance = Random.Range(minSpawnDistance, maxSpawnDistance);

        Vector2 spawnOffset = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle)) * randomDistance;
        Vector2 spawnPosition = playerPosition + spawnOffset;

        return spawnPosition;
    }

    private GameObject GetRandomAlienPrefab(GameObject[] prefabs)
    {
        int randomIndex = Random.Range(0, prefabs.Length);
        return prefabs[randomIndex];
    }
}


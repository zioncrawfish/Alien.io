using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] alienPrefabs;

    public int initialAlienCount = 25;
    public float spawnInterval = 3f;
    public int maxAlienCount = 100;
    public float minSpawnDistance = 10f;
    public float maxSpawnDistance = 30f;

    private Camera mainCamera;
    private Transform playerTransform;
    private List<GameObject> activeAliens = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        playerTransform = GameObject.FindGameObjectWithTag("Player")?.transform;

        SpawnInitialAliens();
        StartCoroutine(SpawnAliens());
    }

    private void SpawnInitialAliens()
    {
        for (int i = 0; i < initialAlienCount; i++)
        {
            SpawnAlien();
        }
    }

    private IEnumerator SpawnAliens()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (activeAliens.Count < maxAlienCount)
            {
                SpawnAlien();
            }
        }
    }

    private void SpawnAlien()
    {
        Vector2 spawnPosition = GetRandomSpawnPosition();
        GameObject alienPrefab = GetRandomAlienPrefab();

        GameObject alienInstance = Instantiate(alienPrefab, spawnPosition, Quaternion.identity);
        activeAliens.Add(alienInstance);
    }

    private Vector2 GetRandomSpawnPosition()
    {
        if (playerTransform == null)
        {
            Debug.LogError("Player transform not found.");
            return Vector2.zero;
        }

        Vector2 playerPosition = playerTransform.position;
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        float randomDistance = Random.Range(minSpawnDistance, maxSpawnDistance);
        Vector2 spawnPosition = playerPosition + randomDirection * randomDistance;

        return spawnPosition;
    }

    private GameObject GetRandomAlienPrefab()
    {
        int randomIndex = Random.Range(0, alienPrefabs.Length);
        return alienPrefabs[randomIndex];
    }
}

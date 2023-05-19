using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyPrefabs;

    [SerializeField]
    private float[] enemyIntervals;

    private Camera mainCamera;
    private List<Vector3> spawnPoints = new List<Vector3>(); // List to store available spawn points

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        // Calculate the available spawn points
        CalculateSpawnPoints();

        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            StartCoroutine(SpawnEnemy(enemyIntervals[i], enemyPrefabs[i]));
        }
    }

    private IEnumerator SpawnEnemy(float interval, GameObject enemyPrefab)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);

            if (spawnPoints.Count > 0)
            {
                // Randomly select a spawn point
                int randomIndex = Random.Range(0, spawnPoints.Count);
                Vector3 spawnPosition = spawnPoints[randomIndex];
                spawnPoints.RemoveAt(randomIndex); // Remove the selected spawn point from the list

                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    private void CalculateSpawnPoints()
    {
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        Vector3 cameraPosition = mainCamera.transform.position;

        // Calculate the number of spawn points based on camera size
        int numSpawnPoints = Mathf.RoundToInt(cameraWidth) + Mathf.RoundToInt(cameraHeight);

        for (int i = 0; i < numSpawnPoints; i++)
        {
            float spawnX = Random.Range(-cameraWidth / 2f, cameraWidth / 2f);
            float spawnY = Random.Range(-cameraHeight / 2f, cameraHeight / 2f);

            Vector3 spawnPosition = new Vector3(spawnX + cameraPosition.x, spawnY + cameraPosition.y, 0f);
            spawnPoints.Add(spawnPosition);
        }
    }
}
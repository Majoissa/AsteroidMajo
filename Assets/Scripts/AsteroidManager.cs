using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public GameObject[] asteroidPrefabs; // Array de prefabs de asteroides
    public Transform asteroidParent; 
    public float spawnInterval = 2f;
    public float minimumSpawnInterval = 0.5f; 
    public float intervalDecreaseRate = 0.1f; 

    private void Start()
    {
        StartSpawningAsteroids();
    }

    public void StartSpawningAsteroids()
    {
        StartCoroutine(SpawnAsteroidsRoutine());
    }

    private IEnumerator SpawnAsteroidsRoutine()
    {
        while (true)
        {
            SpawnAsteroid(asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)], GetRandomPosition(), Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval); 
            spawnInterval = Mathf.Max(minimumSpawnInterval, spawnInterval - intervalDecreaseRate);
        }
    }

    private void SpawnAsteroid(GameObject asteroidPrefab, Vector3 position, Quaternion rotation)
    {
        GameObject asteroidInstance = Instantiate(asteroidPrefab, position, rotation, asteroidParent);
        
    }

    private Vector3 GetRandomPosition()
    {
        
        float x = Random.Range(-10f, 10f);
        float y = Random.Range(-10f, 10f);
        return new Vector3(x, y, 0);
    }
}

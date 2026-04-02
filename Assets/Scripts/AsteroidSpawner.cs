using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private Transform[] spawnPoints;

    public void SpawnAsteroids()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(
                asteroidPrefab,
                spawnPoints[i].position,
                spawnPoints[i].rotation
            );
        }
    }
}
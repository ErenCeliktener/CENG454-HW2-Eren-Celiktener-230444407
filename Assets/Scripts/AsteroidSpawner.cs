using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Transform playerTarget;

    public void SpawnAsteroids()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject asteroid = Instantiate(
                asteroidPrefab,
                spawnPoints[i].position,
                spawnPoints[i].rotation
            );

            asteroid.GetComponent<AsteroidHoming>().SetTarget(playerTarget);
        }
    }
}
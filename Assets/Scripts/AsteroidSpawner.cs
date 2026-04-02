using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Transform playerTarget;

    private List<GameObject> activeAsteroids = new List<GameObject>();

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
            activeAsteroids.Add(asteroid);
        }
    }

    public void DestroyAllAsteroids()
    {
        for (int i = 0; i < activeAsteroids.Count; i++)
        {
            if (activeAsteroids[i] != null)
            {
                Destroy(activeAsteroids[i]);
            }
        }

        activeAsteroids.Clear();
    }
}
// DangerZoneController.cs
using System.Collections;
using UnityEngine;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private AsteroidSpawner asteroidSpawner;
    [SerializeField] private float spawnDelay = 5f;

    private Coroutine countdownCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (countdownCoroutine == null)
        {
            countdownCoroutine = StartCoroutine(SpawnCountdown());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
            countdownCoroutine = null;
        }
    }

    private IEnumerator SpawnCountdown()
    {
        yield return new WaitForSeconds(spawnDelay);
        asteroidSpawner.SpawnAsteroids();
        countdownCoroutine = null;
    }
}
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
        if (!other.CompareTag("Player")) return; // Start the countdown only when the player enters the danger zone

        if (countdownCoroutine == null) // Prevent multiple countdowns from starting at the same time

        {
            countdownCoroutine = StartCoroutine(SpawnCountdown());
        }
    }

    private void OnTriggerExit(Collider other)
    {
         // Cancel the countdown if the player leaves the danger zone early
        if (!other.CompareTag("Player")) return;

        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
            countdownCoroutine = null;
        }
    }

    private IEnumerator SpawnCountdown()
    {
        yield return new WaitForSeconds(spawnDelay); // Wait before spawning the asteroids
        asteroidSpawner.SpawnAsteroids(); // Spawn the asteroids after the delay
        countdownCoroutine = null;
    }
}
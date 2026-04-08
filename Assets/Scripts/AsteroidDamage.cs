using UnityEngine;

public class AsteroidDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return; // Only react when the asteroid hits the player

        AircraftHealth health = other.GetComponent<AircraftHealth>(); // Get the health script from the player
        health.TakeDamage(); // Apply damage to the player's health

        Destroy(gameObject); // Destroy the asteroid after impact
    }
}
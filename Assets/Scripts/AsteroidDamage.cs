using UnityEngine;

public class AsteroidDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        AircraftHealth health = other.GetComponent<AircraftHealth>();
        health.TakeDamage();

        Destroy(gameObject);
    }
}
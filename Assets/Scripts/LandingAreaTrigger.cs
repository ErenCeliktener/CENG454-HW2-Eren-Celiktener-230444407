using UnityEngine;

public class LandingAreaTrigger : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    private void OnTriggerEnter(Collider other)
    {
        // Complete the mission when the player reaches the landing area
        if (!other.CompareTag("Player")) return;

        examManager.OnReachDestination();
    }
}
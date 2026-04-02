using UnityEngine;

public class LandingAreaTrigger : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        examManager.OnReachDestination();
    }
}
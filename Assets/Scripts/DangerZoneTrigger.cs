// DangerZoneTrigger.cs
using UnityEngine;

public class DangerZoneTrigger : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    private void OnTriggerEnter(Collider other)
    {
        // Notify the mission manager when the player enters the danger zone
        if (!other.CompareTag("Player")) return;

        examManager.EnterDangerZone();
    }

    private void OnTriggerExit(Collider other)
    {
        // Notify the mission manager when the player leaves the danger zone
        if (!other.CompareTag("Player")) return;

        examManager.ExitDangerZone();
    }
}
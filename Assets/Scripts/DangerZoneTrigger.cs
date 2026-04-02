using UnityEngine;

public class DangerZoneTrigger : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        examManager.EnterDangerZone();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        examManager.ExitDangerZone();
    }
}
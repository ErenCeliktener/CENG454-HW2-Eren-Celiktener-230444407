using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text hudText;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Rigidbody spacecraftRb;

    [Header("HUD Messages")]
    [SerializeField] private string startMessage = "Reach the destination hangar!";
    [SerializeField] private string successMessage = "Mission Complete!\nSpacecraft successfully reached the destination hangar!";

    private bool missionComplete = false;

    private void Start()
    {
        RestartMission();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartMission();
        }
    }

    public void OnReachDestination()
    {
        if (missionComplete) return;

        missionComplete = true;

        if (hudText != null)
        {
            hudText.text = successMessage;
        }
    }

    public void RestartMission()
    {
        missionComplete = false;

        if (spacecraftRb != null && spawnPoint != null)
        {
            spacecraftRb.linearVelocity = Vector3.zero;
            spacecraftRb.angularVelocity = Vector3.zero;

            spacecraftRb.transform.position = spawnPoint.position;
            spacecraftRb.transform.rotation = spawnPoint.rotation;
        }

        if (hudText != null)
        {
            hudText.text = startMessage;
        }
    }
}
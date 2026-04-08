// FlightExamManager.cs
using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text hudText;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject spacecraft;
    [SerializeField] private AircraftHealth aircraftHealth;
    [SerializeField] private AsteroidSpawner asteroidSpawner;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip dangerZoneClip;
    [SerializeField] private AudioClip asteroidHitClip;
    [SerializeField] private AudioClip victoryClip;

    [SerializeField] private string startMessage = "Reach the destination hangar!";
    [SerializeField] private string dangerMessage = "Entered a Dangerous Zone!";
    [SerializeField] private string safeMessage = "Danger cleared. Proceed to the destination hangar!";
    [SerializeField] private string successMessage = "Mission Complete!\nSpacecraft successfully reached the destination hangar!";

    private Rigidbody rb;

    private bool hasEnteredDangerZone = false;
    private bool missileCountdownActive = false;
    private bool missileActive = false;
    private bool dangerPhaseCleared = false;
    private bool missionComplete = false;

    private void Start()
    {
        rb = spacecraft.GetComponent<Rigidbody>(); // Get the Rigidbody component of the spacecraft
        RestartMission(); // Start the mission in its default state
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // Restart the mission when the player presses R
        {
            RestartMission();
        }
    }

    public void EnterDangerZone()
    {
        // Do not trigger again if the mission is over or the player is already inside the danger zone
        if (missionComplete || hasEnteredDangerZone) return;
         // Update the danger zone state and HUD message, and play the warning sound
        hasEnteredDangerZone = true;
        missileCountdownActive = true;
        dangerPhaseCleared = false;
        hudText.text = dangerMessage;
        PlayDangerZoneSound();
    }

    public void ExitDangerZone()
    {
        // Ignore exit if the mission is over or the player is not inside the zone
        if (missionComplete || !hasEnteredDangerZone) return;

        // Clear the danger zone state
        hasEnteredDangerZone = false;
        missileCountdownActive = false;
        missileActive = false;
        dangerPhaseCleared = true;

        asteroidSpawner.DestroyAllAsteroids(); // Remove all active asteroids from the scene

        // Show the safe message and play the success sound
        hudText.text = safeMessage;
        audioSource.Stop();
        PlayVictorySound();
    }

    public void SetAsteroidCountdownActive(bool isActive)
    {
        missileCountdownActive = isActive; // Update the countdown state
    }

    public void SetAsteroidActive(bool isActive)
    {
        missileActive = isActive; // Update the active asteroid state
    }

    public void OnReachDestination()
    {
        if (missionComplete) return; // Do not trigger if the mission is already complete

        missionComplete = true; // Set the mission as completed successfully
        hudText.text = successMessage;
    }

    public void UpdateHealthHUD(int currentHealth)
    {
        // Update the separate health text on the HUD to show the current hull integrity, and play the hit sound
        healthText.text = "Hull Integrity: " + currentHealth;
        PlayAsteroidHitSound();
    }

    public void FailMission()
    {
        // Show the mission failed message and play the hit sound when the spacecraft is destroyed, then restart the mission after a short delay
        hudText.text = "Mission Failed!\nSpacecraft destroyed.";
        PlayAsteroidHitSound();
        Invoke(nameof(RestartMission), 2f);
    }

    public void RestartMission()
    {
        // Reset all mission state flags
        hasEnteredDangerZone = false;
        missileCountdownActive = false;
        missileActive = false;
        dangerPhaseCleared = false;
        missionComplete = false;

        // Reset the spacecraft's velocity to stop any movement before repositioning
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Move the spacecraft back to the spawn point
        spacecraft.transform.position = spawnPoint.position;
        spacecraft.transform.rotation = spawnPoint.rotation;

        // Reset player health and clear all asteroids
        aircraftHealth.ResetHealth();
        asteroidSpawner.DestroyAllAsteroids();

        // Restore the default HUD messages
        hudText.text = startMessage;
        healthText.text = "Hull Integrity: 100";
    }

    public void PlayDangerZoneSound()
    {
        audioSource.PlayOneShot(dangerZoneClip); // Play the warning sound
    }

    public void PlayAsteroidHitSound()
    {
        audioSource.PlayOneShot(asteroidHitClip); // Play the asteroid hit sound
    }

    public void PlayVictorySound()
    {
        audioSource.PlayOneShot(victoryClip); // Play the success sound
    }
}
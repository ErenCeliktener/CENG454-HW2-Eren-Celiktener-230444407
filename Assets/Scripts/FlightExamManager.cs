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
        rb = spacecraft.GetComponent<Rigidbody>();
        RestartMission();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartMission();
        }
    }

    public void EnterDangerZone()
    {
        if (missionComplete || dangerPhaseCleared || hasEnteredDangerZone) return;

        hasEnteredDangerZone = true;
        missileCountdownActive = true;
        hudText.text = dangerMessage;
        PlayDangerZoneSound();
    }

    public void ExitDangerZone()
    {
    if (missionComplete || !hasEnteredDangerZone) return;

    missileCountdownActive = false;
    missileActive = false;
    dangerPhaseCleared = true;

    asteroidSpawner.DestroyAllAsteroids();

    hudText.text = safeMessage;
    audioSource.Stop();
    PlayVictorySound();
    }

    public void SetAsteroidCountdownActive(bool isActive)
    {
        missileCountdownActive = isActive;
    }

    public void SetAsteroidActive(bool isActive)
    {
        missileActive = isActive;
    }

    public void OnReachDestination()
    {
        if (missionComplete) return;

        missionComplete = true;
        hudText.text = successMessage;
    }

    public void UpdateHealthHUD(int currentHealth)
    {
        hudText.text = "Hull Integrity: " + currentHealth;
        PlayAsteroidHitSound();
    }

    public void FailMission()
    {
        hudText.text = "Mission Failed!\nSpacecraft destroyed.";
        PlayAsteroidHitSound();
        Invoke(nameof(RestartMission), 2f);
    }

    public void RestartMission()
    {
    hasEnteredDangerZone = false;
    missileCountdownActive = false;
    missileActive = false;
    dangerPhaseCleared = false;
    missionComplete = false;

    rb.linearVelocity = Vector3.zero;
    rb.angularVelocity = Vector3.zero;

    spacecraft.transform.position = spawnPoint.position;
    spacecraft.transform.rotation = spawnPoint.rotation;

    aircraftHealth.ResetHealth();
    asteroidSpawner.DestroyAllAsteroids();

    hudText.text = startMessage;
    healthText.text = "Hull Integrity: 100";
    }
    public void PlayDangerZoneSound()
    {
        audioSource.PlayOneShot(dangerZoneClip);
    }

    public void PlayAsteroidHitSound()
    {
        audioSource.PlayOneShot(asteroidHitClip);
    }

    public void PlayVictorySound()
    {
        audioSource.PlayOneShot(victoryClip);
    }
}
using UnityEngine;

public class AircraftHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int hitDamage = 50;
    [SerializeField] private FlightExamManager examManager;

    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth; // Set the spacecraft health to maximum at the start
    }

    public void TakeDamage()
    {
        currentHealth -= hitDamage;  // Reduce health when hit by an asteroid

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        examManager.UpdateHealthHUD(currentHealth); // Update the health display on the HUD

        if (currentHealth <= 0) 
        {
            examManager.FailMission(); // Fail the mission if health reaches zero
        }
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
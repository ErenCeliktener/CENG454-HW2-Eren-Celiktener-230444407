using UnityEngine;

public class AircraftHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int hitDamage = 50;
    [SerializeField] private FlightExamManager examManager;

    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage()
    {
        currentHealth -= hitDamage;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        examManager.UpdateHealthHUD(currentHealth);

        if (currentHealth <= 0)
        {
            examManager.FailMission();
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
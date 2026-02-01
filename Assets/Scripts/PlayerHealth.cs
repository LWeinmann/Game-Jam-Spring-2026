using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Slider healthBar;
    public GameObject deathScreen; // UI panel or canvas

    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;

        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;

        deathScreen.SetActive(false);
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
            healthBar.value = currentHealth;
    }

    void Die()
    {
        isDead = true;

        // Pause the game
        Time.timeScale = 0f;

        // Show death UI
        deathScreen.SetActive(true);
    }

    public void Revive()
    {
        isDead = false;

        Heal(maxHealth);

        // Resume game
        Time.timeScale = 1f;

        deathScreen.SetActive(false);
    }
}
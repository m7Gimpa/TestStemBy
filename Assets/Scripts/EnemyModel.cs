using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    public int health = 100;

    public delegate void OnHealthChanged(int currentHealth);
    public event OnHealthChanged HealthChanged;

    public void TakeDamage(int damage)
    {
        health -= damage;
        HealthChanged?.Invoke(health);
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " has been destroyed!");
        Destroy(gameObject);
    }
}
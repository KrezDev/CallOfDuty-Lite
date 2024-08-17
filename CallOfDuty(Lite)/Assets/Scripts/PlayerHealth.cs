using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player took damage! Current health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
        gameObject.SetActive(false);
    }
}

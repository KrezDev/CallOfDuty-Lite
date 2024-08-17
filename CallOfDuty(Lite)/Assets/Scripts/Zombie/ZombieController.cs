using UnityEngine;

public class SimpleZombieController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;
    public float detectionRange = 20f;
    public float attackRange = 2f;
    public int health = 100;
    public int damage = 10;

    public float attackCooldown = 2f;

    private bool isDead = false;
    private float attackTimer = 0f;
    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (isDead)
            return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            if (attackTimer <= 0f)
            {
                AttackPlayer();
                attackTimer = attackCooldown;
            }
        }
        else if (distanceToPlayer <= detectionRange)
        {
            MoveTowardsPlayer();
        }

        attackTimer -= Time.deltaTime;
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;

        transform.position += direction * moveSpeed * Time.deltaTime;

        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
    }

    void AttackPlayer()
    {
        Debug.Log("Zombie attacks player!");

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        Debug.Log("Zombie died!");
        Destroy(gameObject, 2f);
    }
}

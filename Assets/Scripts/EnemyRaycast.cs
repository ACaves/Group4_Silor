using UnityEngine;

public class EnemyRaycast : MonoBehaviour
{
    public float health = 100f;


    public void TakeDamage(float amount)
    {
        Debug.LogWarning("Enemy Damage Sustainted");
        health -= amount;

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        Debug.Log("Kraken Died");
    }
}

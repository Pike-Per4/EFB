using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float amout) 
    {
        health -= amout;
        if (health <= 0f) 
        {
            Die();
        }

        void Die() 
        {
            Destroy(gameObject);
        }
    }
}

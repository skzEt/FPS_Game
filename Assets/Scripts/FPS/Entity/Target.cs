using UnityEngine;

public class Target : MonoBehaviour, IDamageble
{
    private float health = 100f;
    public void Damage(float damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(gameObject);
    }
}

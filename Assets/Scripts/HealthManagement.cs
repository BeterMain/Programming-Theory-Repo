using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManagement : MonoBehaviour
{
    public int max_health = 100;
    private int health;
    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public virtual void Start()
    {
        health = max_health;
    }

    public void Hit(int damage) // ABSTRACTION
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }

    public void IncreaseHealth(int amountToIncrease) // ABSTRACTION
    {
        health += amountToIncrease;
        if (health > max_health)
        {
            health = max_health;
        }
    }

    public virtual void Die() // ABSTRACTION
    {
        Destroy(gameObject);
    }
}

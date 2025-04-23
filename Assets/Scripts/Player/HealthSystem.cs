using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField] int currentHealth;


    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void ReceiveHeal(int heal)
    {
        currentHealth += heal;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void ReceiveDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            //currentHealth = 0;
            Destroy(gameObject);
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;
    private void Awake()
    {
        instance = this;
    }
    public float currentHealth, maxHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    
}

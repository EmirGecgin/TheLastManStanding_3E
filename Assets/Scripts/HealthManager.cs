using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public float currentHealth, maxHealth;
    public Slider healthSlider;

    private void Start()
    {
        currentHealth = maxHealth;
        
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    private void Update()
    {
        
    }

    public void TakeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
        healthSlider.value = currentHealth;
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowerWeapon : Weapon
{
    public EnemyDamager damager;
    private float throwCounter;
    void Start()
    {
        SetStats();
    }

    
    void Update()
    {
        if (statsUpdated)
        {
            statsUpdated = false;
            SetStats();
        }

        throwCounter -= Time.deltaTime;
        if (throwCounter <= 0)
        {
            throwCounter = stats[weaponLevel].timeBetweenAttacks;
            for (int i = 0; i < stats[weaponLevel].amount; i++)
            {
                Instantiate(damager,damager.transform.position,damager.transform.rotation).gameObject.SetActive(true);
            }
        }
    }

    void SetStats()
    {
        damager.damageAmount = stats[weaponLevel].damage;
        damager.lifeTime = stats[weaponLevel].duration;
        
        damager.transform.localScale = Vector3.one * stats[weaponLevel].range;

        throwCounter = 0f;
    }
}

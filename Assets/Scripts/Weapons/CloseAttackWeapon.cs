using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAttackWeapon : Weapon
{
    public EnemyDamager damager;

    private float _attackCounter, _direction;

    private void Start()
    {
        SetStats();
    }

    private void Update()
    {
        if (statsUpdated)
        {
            statsUpdated = false;
            SetStats();
        }

        _attackCounter -= Time.deltaTime;
        if (_attackCounter <= 0)
        {
            _attackCounter = stats[weaponLevel].timeBetweenAttacks;
            _direction = Input.GetAxisRaw("Horizontal");
            if (_direction != 0)
            {
                if (_direction > 0)
                {
                    damager.transform.rotation = Quaternion.identity;
                    
                }
                else
                {
                    damager.transform.rotation = Quaternion.Euler(0f,0f,180f);
                }
                
            }
            Instantiate(damager,damager.transform.position,damager.transform.rotation,transform).
                gameObject.SetActive(true);
            
            for (int i = 1; i < stats[weaponLevel].amount; i++)
            {
                float rotation = (360f / stats[weaponLevel].amount) * i;
                Instantiate(damager,damager.transform.position,Quaternion.Euler(0f,0f,damager.transform.rotation.eulerAngles.z+rotation),transform).gameObject.SetActive(true);

            }
        }
    }

    void SetStats()
    {
        damager.damageAmount = stats[weaponLevel].damage;
        damager.lifeTime = stats[weaponLevel].duration;
        
        damager.transform.localScale = Vector3.one * stats[weaponLevel].range;

        _attackCounter = 0f;
    }
}

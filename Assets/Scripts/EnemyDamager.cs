using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    [SerializeField] private float damageAmount;
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag=="Enemy")
        {
            col.GetComponent<EnemyController>().TakeDamage(damageAmount);
        }
    }
}

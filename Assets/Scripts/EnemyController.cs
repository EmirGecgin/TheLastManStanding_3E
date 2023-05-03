using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private float enemySpeed;
    private Transform _target;
    public float damage;
    public float hitWaitTime = 1f;
    private float hitCounter;
    
    public void Awake()
    {
        _target = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    public void Update()
    {
        rb.velocity = (_target.position - transform.position).normalized * enemySpeed;
        if (hitCounter > 0f)
        {
            hitCounter -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" && hitCounter <= 0f)
        {
            HealthManager.instance.TakeDamage(damage);
            hitCounter = hitWaitTime;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private float enemySpeed;
    private Transform _target;
    
    public void Awake()
    {
        _target = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    public void Update()
    {
        rb.velocity = (_target.position - transform.position).normalized * enemySpeed;
    }

    
}

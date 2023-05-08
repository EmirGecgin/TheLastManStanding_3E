using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    [SerializeField] private float damageAmount;

    [SerializeField] private float lifeTime,growSpeed = 5f;
    private Vector3 _targetSize;

    private void Start()
    {
        _targetSize = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    private void Update()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, 
            _targetSize, growSpeed * Time.deltaTime);
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            _targetSize = Vector3.zero;
            if (transform.localScale.x == 0f)
            {
                Destroy(gameObject);
            }
        }

    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag=="Enemy")
        {
            col.GetComponent<EnemyController>().TakeDamage(damageAmount);
        }
    }
}

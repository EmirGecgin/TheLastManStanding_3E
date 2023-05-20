using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyDamager : MonoBehaviour
{
    public float damageAmount;

    public float lifeTime,growSpeed = 5f;
    private Vector3 _targetSize;
    public bool shouldKnockBack;
    public bool destroyParent;

    public bool damageOverTime;
    public float timeBetweenDamage;
    public float damageCounter;

    private List<EnemyController> _enemiesInRange = new List<EnemyController>();

    public bool destroyOnImpact;
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
                if (destroyParent)
                {
                    Destroy(transform.parent.gameObject);
                }
            }
        }

        if (damageOverTime == true)
        {
            damageCounter -= Time.deltaTime;
            if (damageCounter <= 0)
            {
                damageCounter = timeBetweenDamage;
                for (int i = 0; i < _enemiesInRange.Count; i++)
                {
                    if (_enemiesInRange[i] != null)
                    {
                        _enemiesInRange[i].TakeDamage(damageAmount,shouldKnockBack);
                        
                    }
                    else
                    {
                        _enemiesInRange.RemoveAt(i);
                        i--;
                    }
                }
            }
        }

    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (damageOverTime == false)
        {
            if (col.tag=="Enemy")
            {
                col.GetComponent<EnemyController>().TakeDamage(damageAmount,shouldKnockBack);

                if (destroyOnImpact)
                {
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            if (col.tag == "Enemy")
            {
                _enemiesInRange.Add(col.GetComponent<EnemyController>());
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (damageOverTime == true)
        {
            if (other.tag == "Enemy")
            {
                _enemiesInRange.Remove(other.GetComponent<EnemyController>());
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private float enemySpeed;
    private Transform _target;
    public float damage;
    public float hitWaitTime = 1f;
    private float _hitCounter;
    [SerializeField] private float health = 5;
    [SerializeField] private float knockBackTime=.5f;
    private float _knockBackCounter;

    public int expToGive;

    public int coinValue = 1;
    public float coinDropRate = 0.5f;
    

    public void Start()
    {
        //_target = FindObjectOfType<PlayerMovement>().transform;
        _target = HealthManager.Instance.transform;
    }

    
    public void Update()
    {
        if (PlayerMovement.Instance.gameObject.activeSelf == true)
        {


            if (_knockBackCounter > 0)
            {
                _knockBackCounter -= Time.deltaTime;

                if (enemySpeed > 0)
                {
                    enemySpeed = -enemySpeed * 2;
                }

                if (_knockBackCounter <= 0)
                {
                    enemySpeed = Math.Abs(enemySpeed * .5f);
                }
            }

            rb.velocity = (_target.position - transform.position).normalized * enemySpeed;
            if (_hitCounter > 0f)
            {
                _hitCounter -= Time.deltaTime;
            }
        }
        else
        {
            rb.velocity=Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" && _hitCounter <= 0f)
        {
            HealthManager.Instance.TakeDamage(damage);
            _hitCounter = hitWaitTime;
        }
    }

    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;
        if (health <= 0)
        {
            Destroy(gameObject);
            ExperienceLevelController.Instance.SpawnExp(transform.position,expToGive);
            float randomValue = UnityEngine.Random.Range(0f, 1f);

            if (randomValue <= coinDropRate)
            {
                CoinController.Instance.DropCoin(transform.position,coinValue);
            }
            SFXManager.instance.PlaySfxPitched(0);
        }
        else
        {
            SFXManager.instance.PlaySfxPitched(1);
        }
        DamageNumberController.Instance.SpawnDamage(damageToTake,transform.position);
    }

    public void TakeDamage(float damageToTake, bool shouldKnockBack)
    {
        TakeDamage(damageToTake);
        if (shouldKnockBack == true)
        {
            _knockBackCounter = knockBackTime;
        }   
    }
}

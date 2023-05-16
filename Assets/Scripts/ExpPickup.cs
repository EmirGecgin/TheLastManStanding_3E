using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPickup : MonoBehaviour
{
    public int expValue;
    private bool _movingToPlayer;
    [SerializeField] private float pickUpSpeed;
    [SerializeField] private float timeBetweenChecks = 0.2f;
    private float _checkCounter;
    
    private PlayerMovement _player;

    private void Start()
    {
        _player = HealthManager.Instance.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        GoToPlayer();
    }

    public void GoToPlayer()
    {
        if (_movingToPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position,
                pickUpSpeed * Time.deltaTime);
        }
        else
        {
            _checkCounter -= Time.deltaTime;
            if (_checkCounter <= 0)
            {
                _checkCounter = timeBetweenChecks;
                if (Vector3.Distance(transform.position, _player.transform.position) < _player.pickUpRange)
                {
                    _movingToPlayer = true;
                    pickUpSpeed += _player.playerSpeed;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            ExperienceLevelController.Instance.GetExp(expValue);
            Destroy(gameObject);
        }
    }
}

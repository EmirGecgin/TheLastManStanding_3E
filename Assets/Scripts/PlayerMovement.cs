using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D _rb;
    private Vector2 _moveAmount;
    private Animator _anim;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        GetMove();
    }

    private void FixedUpdate()
    {
        SetMove();
    }

    void GetMove()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _moveAmount = moveInput.normalized * speed;
        if (moveInput != Vector2.zero)
        {
            _anim.SetBool("isRunning",true);
        }
        else
        {
            _anim.SetBool("isRunning",false);
        }
    }

    void SetMove()
    {
        _rb.MovePosition(_rb.position + _moveAmount * Time.fixedDeltaTime);
    }
}

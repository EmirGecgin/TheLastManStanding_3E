using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    private Animator _anim;

    public float pickUpRange;
    
    
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        Move();
        
    }


    private void Move()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0f);//take moveInput
        moveInput.Normalize();//normalize
        transform.position += moveInput * playerSpeed * Time.deltaTime;//movePlayer
        if (moveInput != Vector3.zero)//decide which anim use
        {
            _anim.SetBool("isRunning",true);//run
            
        }
        else
        {
            _anim.SetBool("isRunning",false);//idle
            
        }
    }

    
}

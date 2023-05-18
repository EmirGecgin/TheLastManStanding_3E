using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    private void Awake()
    {
        Instance = this;
    }

    public float playerSpeed;
    private Animator _anim;

    public float pickUpRange;
    
    //public Weapon activeWeapon;

    public List<Weapon> unassignedWeapons, assignedWeapons;

    public int maxWeapons = 3;
    [HideInInspector] public List<Weapon> fullyLevelledWeapons = new List<Weapon>();
    private void Start()
    {
        _anim = GetComponent<Animator>();
        AddWeapon(Random.Range(0, unassignedWeapons.Count));

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

    public void AddWeapon(int Weaponnumber)
    {
        if (Weaponnumber < unassignedWeapons.Count)
        {
            assignedWeapons.Add((unassignedWeapons[Weaponnumber]));
            unassignedWeapons[Weaponnumber].gameObject.SetActive(true);
            unassignedWeapons.RemoveAt(Weaponnumber);
        }
    }

    public void AddWeapon(Weapon weaponToAdd)
    {
        weaponToAdd.gameObject.SetActive(true);
        assignedWeapons.Add((weaponToAdd));
        unassignedWeapons.Remove(weaponToAdd);
    }

    
}

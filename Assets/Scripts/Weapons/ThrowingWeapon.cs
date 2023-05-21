using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ThrowingWeapon : MonoBehaviour
{
    public float throwingPower;
    public Rigidbody2D throwingWeaponRb;
    public float rotationSpeed;
    void Start()
    {
        throwingWeaponRb.velocity = new Vector2(Random.Range(-throwingPower, throwingPower),throwingPower);
    }

    
    void Update()
    {
        transform.rotation=Quaternion.Euler(0,0,transform.rotation.eulerAngles.z+(rotationSpeed*360*Time.deltaTime*Mathf.Sign(throwingWeaponRb.velocity.x)));
    }
}

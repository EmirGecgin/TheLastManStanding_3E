using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballWeapon : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform fireballHolder;
    void Start()
    {
        
    }

    
    void Update()
    {
        fireballHolder.transform.rotation =
            Quaternion.Euler(0f, 0f, fireballHolder.transform.rotation.eulerAngles.z + (rotationSpeed * Time.deltaTime));
    }
}

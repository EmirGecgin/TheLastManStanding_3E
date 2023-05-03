using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _target;

    private void Awake()
    {
        _target = FindObjectOfType<PlayerMovement>().transform;
    }
    private void LateUpdate()
    {
        SetCamera();
    }
    private void SetCamera()
    {
        transform.position = new Vector3(_target.position.x, _target.position.y, transform.position.z);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float speed;

    private void Awake()
    {
        transform.position = playerTransform.position;
    }

    private void LateUpdate()
    {
        CameraMovement();
    }

    private void CameraMovement()
    {
        if (playerTransform != null)
        {
            transform.position = Vector2.Lerp(transform.position, playerTransform.position, speed);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceLevelController : MonoBehaviour
{
    public static ExperienceLevelController Instance;
    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private int currentExp;
    public ExpPickup expPickUp;

    public void GetExp(int amountToGet)
    {
        currentExp += amountToGet;
    }

    public void SpawnExp(Vector3 position,int expValue)
    {
        Instantiate(expPickUp, position, Quaternion.identity).expValue = expValue;
    }
}

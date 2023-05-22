using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatController : MonoBehaviour
{
    public static PlayerStatController instance;

    private void Awake()
    {
        instance = this;
    }

    public List<PlayerStatValue> moveSpeed, health, pickupRange, maxWeapon;
    public int moveSpeedLevelCount, healthLevelCount, pickupRangeLevelCount;

    public int moveSpeedLevel, healthLevel, pickupLevel, maxWeaponsLevel;

    private void Start()
    {
        for (int i = moveSpeed.Count-1; i < moveSpeedLevelCount; i++)
        {
            moveSpeed.Add(new PlayerStatValue(moveSpeed[i].cost+moveSpeed[1].cost,moveSpeed[i].value+(moveSpeed[1].value-moveSpeed[0].value)));    
        }
        for (int i = health.Count-1; i < healthLevelCount; i++)
        {
            health.Add(new PlayerStatValue(health[i].cost+health[1].cost,health[i].value+(health[1].value-health[0].value)));    
        }
        for (int i = pickupRange.Count-1; i < pickupRangeLevelCount; i++)
        {
            pickupRange.Add(new PlayerStatValue(pickupRange[i].cost+pickupRange[1].cost,pickupRange[i].value+(pickupRange[1].value-pickupRange[0].value)));    
        }
    }
}
[System.Serializable]
public class PlayerStatValue
{
    public int cost;
    public float value;

    public PlayerStatValue(int newCost, float newValue)
    {
        cost = newCost;
        value = newValue;
    }
}

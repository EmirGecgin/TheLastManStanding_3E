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

    private void Update()
    {
        if (UIController.Instance.LevelUpPanel.activeSelf == true)
        {
            UpdateDisplay();
        }
    }

    public void UpdateDisplay()
    {
        if (moveSpeedLevel < moveSpeed.Count - 1)
        {
            UIController.Instance.moveSpeedUpgradeDisp.UpdateDisplay(moveSpeed[moveSpeedLevel+1].cost ,moveSpeed[moveSpeedLevel].value,moveSpeed[moveSpeedLevel+1].value);
        }
        else
        {
            UIController.Instance.moveSpeedUpgradeDisp.ShowMaxLevel();
        }
        
        if (healthLevel < health.Count - 1)
        {
            UIController.Instance.healthUpgradeDisp.UpdateDisplay(health[healthLevel+1].cost ,health[healthLevel].value,health[healthLevel+1].value);
        }
        else
        {
            UIController.Instance.healthUpgradeDisp.ShowMaxLevel();
        }
        
        if (pickupLevel < pickupRange.Count - 1)
        {
            UIController.Instance.pickupRangeUpgradeDisp.UpdateDisplay(pickupRange[pickupLevel+1].cost ,pickupRange[pickupLevel].value,pickupRange[pickupLevel+1].value);
        }
        else
        {
            UIController.Instance.pickupRangeUpgradeDisp.ShowMaxLevel();
        }
        
        if (maxWeaponsLevel < maxWeapon.Count - 1)
        {
            UIController.Instance.maxWeaponUpgradeDisp.UpdateDisplay(maxWeapon[maxWeaponsLevel+1].cost ,maxWeapon[maxWeaponsLevel].value,maxWeapon[maxWeaponsLevel+1].value);
        }
        else
        {
            UIController.Instance.maxWeaponUpgradeDisp.ShowMaxLevel();
        }
        
    }

    public void PurchaseMoveSpeed()
    {
        moveSpeedLevel++;
        CoinController.Instance.SpendCoin(moveSpeed[moveSpeedLevel].cost);
        UpdateDisplay();

        PlayerMovement.Instance.playerSpeed = moveSpeed[moveSpeedLevel].value;
    }

    public void PurchaseHealth()
    {
        healthLevel++;
        CoinController.Instance.SpendCoin(health[healthLevel].cost);
        UpdateDisplay();

        HealthManager.Instance.maxHealth = health[healthLevel].value;
        HealthManager.Instance.currentHealth += health[healthLevel].value - health[healthLevel - 1].value;
    }

    public void PurchasePickupRange()
    {
        pickupLevel++;
        CoinController.Instance.SpendCoin(pickupRange[pickupLevel].cost);
        UpdateDisplay();

        PlayerMovement.Instance.pickUpRange = pickupRange[pickupLevel].value;
    }

    public void PurchaseMaxWeapons()
    {
        maxWeaponsLevel++;
        CoinController.Instance.SpendCoin(maxWeapon[maxWeaponsLevel].cost);
        UpdateDisplay();

        PlayerMovement.Instance.maxWeapons = Mathf.RoundToInt(maxWeapon[maxWeaponsLevel].value);
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

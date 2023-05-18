using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public List<WeaponStats> stats;
    public int weaponLevel;

    [HideInInspector] public bool statsUpdated;

    public Sprite icon;
    
    public void LevelUp()
    {
        if (weaponLevel < stats.Count - 1)
        {
            weaponLevel++;
            statsUpdated = true;
            if (weaponLevel >= stats.Count - 1)
            {
                PlayerMovement.Instance.fullyLevelledWeapons.Add(this);
                PlayerMovement.Instance.assignedWeapons.Remove(this);
            }
            
        }
    }
}

[System.Serializable]

public class WeaponStats
{
    public float speed, damage, range, timeBetweenAttacks, amount, duration;
    public string upgradeText;
}

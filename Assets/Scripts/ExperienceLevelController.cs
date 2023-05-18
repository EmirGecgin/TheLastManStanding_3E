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

    [SerializeField] private List<int> expLevels;
    [SerializeField] private int currentLevel=1, levelCount=100;

    private void Start()
    {
        while (expLevels.Count < levelCount)
        {
            expLevels.Add(Mathf.CeilToInt(expLevels[expLevels.Count-1]*1.1f));
        }
    }

    public void GetExp(int amountToGet)
    {
        currentExp += amountToGet;
        if (currentExp >= expLevels[currentLevel])
        {
            LevelUp();
        }
        UIController.Instance.UpdateExperience(currentExp,expLevels[currentLevel],currentLevel);
    }

    public void SpawnExp(Vector3 position,int expValue)
    {
        Instantiate(expPickUp, position, Quaternion.identity).expValue = expValue;
    }

    public void LevelUp()
    {
        currentExp -= expLevels[currentLevel];
        currentLevel++;
        if (currentLevel >= expLevels.Count)
        {
            currentLevel = expLevels.Count - 1;
        }
        
        //PlayerMovement.Instance.activeWeapon.LevelUp();
        UIController.Instance.LevelUpPanel.SetActive(true);
        Time.timeScale = 0f;
        
        //UIController.Instance.levelUpButtons[1].UpdateButtonDisplayFunc(PlayerMovement.Instance.activeWeapon);
        UIController.Instance.levelUpButtons[0].UpdateButtonDisplayFunc(PlayerMovement.Instance.assignedWeapons[0]);
        UIController.Instance.levelUpButtons[1].UpdateButtonDisplayFunc(PlayerMovement.Instance.unassignedWeapons[0]);
        UIController.Instance.levelUpButtons[2].UpdateButtonDisplayFunc(PlayerMovement.Instance.unassignedWeapons[1]);
    }
}

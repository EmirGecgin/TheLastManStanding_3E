using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
    public List<Weapon> weaponsToUpgrade;

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
        //UIController.Instance.levelUpButtons[0].UpdateButtonDisplayFunc(PlayerMovement.Instance.assignedWeapons[0]);
        //UIController.Instance.levelUpButtons[1].UpdateButtonDisplayFunc(PlayerMovement.Instance.unassignedWeapons[0]);
        //UIController.Instance.levelUpButtons[2].UpdateButtonDisplayFunc(PlayerMovement.Instance.unassignedWeapons[1]);
        weaponsToUpgrade.Clear();
        List<Weapon> availableWeapons = new List<Weapon>();
        availableWeapons.AddRange(PlayerMovement.Instance.assignedWeapons);

        if (availableWeapons.Count > 0)
        {
            int selected = Random.Range(0, availableWeapons.Count);
            weaponsToUpgrade.Add(availableWeapons[selected]);
            availableWeapons.RemoveAt(selected);
        }

        if (PlayerMovement.Instance.assignedWeapons.Count + PlayerMovement.Instance.fullyLevelledWeapons.Count < PlayerMovement.Instance.maxWeapons)
        {
            availableWeapons.AddRange(PlayerMovement.Instance.unassignedWeapons);
        }
        
        for (int i = weaponsToUpgrade.Count; i < 3; i++)
        {
            if (availableWeapons.Count > 0)
            {
                int selected = Random.Range(0, availableWeapons.Count);
                weaponsToUpgrade.Add(availableWeapons[selected]);
                availableWeapons.RemoveAt(selected);
            }
            
        }
        
        for(int i = 0 ; i <weaponsToUpgrade.Count;i++)
        {
            UIController.Instance.levelUpButtons[i].UpdateButtonDisplayFunc(weaponsToUpgrade[i]);
        }

        for (int i = 0; i < UIController.Instance.levelUpButtons.Length; i++)
        {
            if (i < weaponsToUpgrade.Count)
            {
                UIController.Instance.levelUpButtons[i].gameObject.SetActive(true);
            }
            else
            {
                UIController.Instance.levelUpButtons[i].gameObject.SetActive(false);
            }
        }
        PlayerStatController.instance.UpdateDisplay();
    }
}

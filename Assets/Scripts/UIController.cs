using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    public static UIController Instance;

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private Slider expLevelSlider;
    [SerializeField] private TMP_Text expLevelText;

    public LevelUpSelectionButton[] levelUpButtons;

    public GameObject LevelUpPanel;

    public TMP_Text coinText;

    public void UpdateExperience(int currentExp, int levelExp,int currentLevel)
    {
        expLevelSlider.maxValue = levelExp;
        expLevelSlider.value = currentExp;
        expLevelText.text = "Level: " + currentLevel;
    }

    public void SkipLevelUp()
    {
        LevelUpPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void UpdateCoins()
    {
        coinText.text = "Coins: " + CoinController.Instance.currentCoins;
    }
}

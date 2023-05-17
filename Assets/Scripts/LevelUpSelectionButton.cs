using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUpSelectionButton : MonoBehaviour
{
    public TMP_Text upgradeDescriptionTxt, nameLvlTxt;
    public Image weaponIcon;

    private Weapon _assignedWeapon;

    public void UpdateButtonDisplayFunc(Weapon theWeapon)
    {
        upgradeDescriptionTxt.text = theWeapon.stats[theWeapon.weaponLevel].upgradeText;
        weaponIcon.sprite = theWeapon.icon;

        nameLvlTxt.text = theWeapon.name + " - Level " + theWeapon.weaponLevel;

        _assignedWeapon = theWeapon;
    }

    public void SelectUpgrade()
    {
        if (_assignedWeapon!=null)
        {
            _assignedWeapon.LevelUp();
            UIController.Instance.LevelUpPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}

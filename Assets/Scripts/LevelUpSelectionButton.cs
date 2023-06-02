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
        if (theWeapon.gameObject.activeSelf == true)
        {
            upgradeDescriptionTxt.text = theWeapon.stats[theWeapon.weaponLevel].upgradeText;
            weaponIcon.sprite = theWeapon.icon;

            nameLvlTxt.text = theWeapon.name /* " - Level " + theWeapon.weaponLevel*/;
        }
        else
        {
            upgradeDescriptionTxt.text = "Unlock " + theWeapon.name;
            weaponIcon.sprite = theWeapon.icon;

            nameLvlTxt.text = theWeapon.name;
        }
        _assignedWeapon = theWeapon;
    }

    public void SelectUpgrade()
    {
        if (_assignedWeapon!=null)
        {
            if (_assignedWeapon.gameObject.activeSelf == true)
            {
                _assignedWeapon.LevelUp();
            }
            else
            {
                PlayerMovement.Instance.AddWeapon(_assignedWeapon);
            }
            UIController.Instance.LevelUpPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}

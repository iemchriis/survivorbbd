using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    [SerializeField]private BaseWeapon currentWeapon;
    [SerializeField]private WeaponHolder playerWeaponHolder;

    private void Awake()
    {
        Time.timeScale = 0;
        
    }


    public void SelectBallisticWeapon()
    {
        playerWeaponHolder.gameObject.AddComponent<BallisticWeapon>();
        currentWeapon = playerWeaponHolder.gameObject.GetComponent<BallisticWeapon>();
        GameUIManager.Instance.selectionPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void SelectLaserWeapon()
    {
        playerWeaponHolder.gameObject.AddComponent<LaserWeapon>();
        currentWeapon = playerWeaponHolder.gameObject.GetComponent<LaserWeapon>();
        GameUIManager.Instance.selectionPanel.SetActive(false);
        Time.timeScale = 1;
    }


}

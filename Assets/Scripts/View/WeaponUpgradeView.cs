using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUpgradeView : MonoBehaviour
{
    public GameObject weaponUpgradePopUp;

    [Header("Base Weapon Stats")]
    public Text weaponLevel;
    public Text damage;
    public Text rateOfFire;
    public Text range;
    public Text critChance;
    [Space]
    [Header("Ballistic Stats")]
    public Text pierceCount;
    [Space]
    [Header("Laser Stats")]
    public Text burnDuration;
    public Text burnDamage;
    [Space]
    [Header("Rocket Stats")]
    public Text explosionDamage;
    public Text explosionRadius;
    [Space]
    [Header("Shotgun Stats")]
    public Text pelletCount;
    public Text spreadRadius;
    
}

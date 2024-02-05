using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponDatas : ScriptableObject
{
   
    public GameObject projectile;
    public float projectileSpeed;
    [Space]
    public int weaponLevel;
    [Space]
    public int damage;
    private int critDamage;
    private float critMultiplier;
    [Space]
    public float fireRate;
    private float fireTime = 0f;



}

[CreateAssetMenu(fileName = "Ballistic", menuName = "Weapons/Ballistic")]
public class BallisticData:WeaponDatas
{
    [Header("Piercing Properties")]
    public bool canPierce;
    public int pierceCount;
}

[CreateAssetMenu(fileName = "Laser", menuName = "Weapons/Laser")]
public class LaserData : WeaponDatas
{
    [Header("Laser Properties")]
    public float laserRange;
    public float burnDamage;
    public float burnDuration;
    public float burnTicks;
}

[CreateAssetMenu(fileName = "Shotgun", menuName = "Weapons/Shotgun")]
public class ShotgunData : WeaponDatas
{
    [Header("Shotgun Properties")]
    public float rangeDropOff;
    public int pelletCount;
    public float spreadAngle;
    public int spreadRandom;
}

[CreateAssetMenu(fileName = "Rocket", menuName = "Weapons/Rocket")]
public class RocketData : WeaponDatas
{
    [Header("Rocket Properties")]
    public float splashRadius;
    
}

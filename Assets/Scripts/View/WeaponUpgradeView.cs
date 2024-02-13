using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUpgradeView : MonoBehaviour
{

    public WeaponUpgradePresenter presenter;
    public GameObject weaponUpgradePopUp;
    public Text weaponName;
    public Image weaponImage;
    [Header("Base Weapon Stats")]
    public Text damage;
    public Text rateOfFire;
    public Text range;
    public Text critChance;
    [Space]
    [Header("Special Characteristic")]
    public Text EffectName;
    public Text EffectStat;
   

    [Header("Next Weapon Stats")]
    public Text NextDamage;
    public Text nextRateOfFire;
    public Text nextRange;
    public Text nextCritChance;
    public Text nextEffectStat;

    //[Space]
    //[Header("Laser Stats")]
    //public Text burnDuration;
    //public Text burnDamage;
    //[Space]
    //[Header("Rocket Stats")]
    //public Text explosionDamage;
    //public Text explosionRadius;
    //[Space]
    //[Header("Shotgun Stats")]
    //public Text pelletCount;
    //public Text spreadRadius;

    public void SetDataToUI()
    {
        int curIndex = presenter.model.weaponIndex;

        weaponName.text = presenter.model.GetWeaponName();
        weaponImage.sprite = presenter.model.GetWeaponSprite();
        damage.text = presenter.model.weaponDatas[curIndex].GetCurrentDamage().ToString();
        rateOfFire.text = presenter.model.weaponDatas[curIndex].GetCurrentFireRate().ToString();
        range.text = presenter.model.weaponDatas[curIndex].GetDamageRange().ToString();
        critChance.text = presenter.model.weaponDatas[curIndex].GetCurrentCritRate().ToString();

        EffectName.text = presenter.model.GetSpecialEffect();
        EffectStat.text = presenter.model.GetSpecialStat(curIndex).ToString();


        NextDamage.text = presenter.model.GetNextDamage().ToString();
        nextRateOfFire.text = presenter.model.GetNextROF().ToString();
        nextRange.text = presenter.model.GetNextRange().ToString(); 
        nextCritChance.text = presenter.model.GetNextCritChance().ToString();   
        nextEffectStat.text = presenter.model.GetNextSpecialStat(curIndex).ToString();  
        
    }

}

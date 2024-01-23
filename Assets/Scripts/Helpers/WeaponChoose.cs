using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WeaponChoose : MonoBehaviour
{
    public int weaponIndex;
    private void OnTriggerEnter(Collider other)
    {
        PlayerDataManager.Instance.currentWeapon = weaponIndex;
        SceneManager.LoadScene("Game 1");
    }
}

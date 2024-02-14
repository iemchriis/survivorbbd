using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponUpgradeExit : MonoBehaviour
{
    [SerializeField] private WeaponUpgradePresenter presenter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(presenter.selection.currentWeapon != null)
            {
                SceneManager.LoadScene("Game 1");
            }
            else
            {
                presenter.view.ShowNotice();
            }
        }
    }
}

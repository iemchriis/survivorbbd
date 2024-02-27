using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponUpgradeExit : MonoBehaviour
{
    [SerializeField] private WeaponUpgradePresenter presenter;
    [SerializeField] private string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(presenter.selection.currentWeapon != null)
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                presenter.view.ShowNotice();
            }
        }
    }
}

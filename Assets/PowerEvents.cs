using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PowerEvents : MonoBehaviour
{
    public static PowerEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action OnBomb;

    public void TriggerBomb()
    {
        if (OnBomb != null)
        {
            OnBomb();
        }
    }

}

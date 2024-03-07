using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHealth : EnemyScript, IDamagable
{
    private void Update()
    {
        DebuffTimer();
    }
}

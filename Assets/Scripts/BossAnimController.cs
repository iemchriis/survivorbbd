using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimController : MonoBehaviour
{

    public ProjectileBoss boss;
  


    public void Throw()
    {
        boss.Throw();
    }

    public void StopAnim()
    {
        boss.StopAnim();
    }


    public void SpawnMinions()
    {
        boss.SpawnMinions();
    }


    public void StopSummon()
    {
        boss.StopSummon();
    }
}

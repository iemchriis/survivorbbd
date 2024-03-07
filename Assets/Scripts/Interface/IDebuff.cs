using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISlowed
{
   
    public void ApplySlowEffect(int debuffAmount, float debuffDuration);

    public IEnumerator ApplySlowEffectAsync(int debuffAmount, float debuffDuration);


}

public interface IStunned
{
    public void ApplyStun(float stunDuration);

    public IEnumerator ApplyStunAsync(float stunDuration);
}




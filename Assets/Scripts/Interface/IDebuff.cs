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


public interface ITakeDamage
{
    public void TakeDamage(int damage);
}

public interface ITakeDamageOverTime
{
    public void TakeDamageOverTime(int damage, float duration, float ticks);

    public IEnumerator TakeDamageOverTimeAsync(int damage, float duration, float ticks);
}

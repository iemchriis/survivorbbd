using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDebuff
{
   
    public void ApplyEffect(int debuffAmount, float debuffDuration);

    public IEnumerator ApplyEffectAsync(int debuffAmount, float debuffDuration);


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

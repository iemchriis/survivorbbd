using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDebuff
{
   
    public void ApplyEffect(int debuffAmount, float debuffDuration);

    public IEnumerator ApplyEffectAsync(int debuffAmount, float debuffDuration);


}

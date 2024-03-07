using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
   void TakeDamage(int damage,CharacterBase.DamageType damageType = CharacterBase.DamageType.NORMAL);

   void TakeDamageOverTime(int damage, float duration, int tickTime);
}

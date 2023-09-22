using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagble
{
    public int HP { get;}
    public void TakeDamage(int damage);
}

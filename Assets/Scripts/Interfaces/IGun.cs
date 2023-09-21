using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Only for firearms. For melee weapons, use IWeapon
/// </summary>
public interface IGun : IWeapon
{
   
    IAmmunition ammo { get; }
}

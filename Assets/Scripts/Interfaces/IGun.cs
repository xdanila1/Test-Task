using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Only for firearms. For melee weapons, use IWeapon
/// </summary>
public interface IGun : IWeapon
{
    int MagazineSize { get; }
    float TimeReload { get; }
    AmmunitionItem Ammo { get; }
}

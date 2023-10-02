using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Only for firearms. For melee weapons, use IWeapon
/// </summary>
public interface IGun //: Weapon
{
    bool IsAutomatic { get; } // лучше использовать enum
    int MagazineSize { get; }
    float TimeReload { get; }
    AmmunitionItem Ammo { get; }
}

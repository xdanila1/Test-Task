using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// It is planned that this interface is only for melee weapons
/// </summary>
public interface IWeapon
{
    Item ItemAsset { get; }
    int Damage { get; }
    float FireRate { get; }
    AudioClip ShotSound { get; }
}

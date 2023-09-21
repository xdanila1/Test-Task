using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAmmunition
{
    Item ItemAsset { get; }
    float DamageBullet { get; }  // buf for gun damage
}

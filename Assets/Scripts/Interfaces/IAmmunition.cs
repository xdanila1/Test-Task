using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAmmunition : IItem
{
    float DamageBullet { get; }  // buf for gun damage
}

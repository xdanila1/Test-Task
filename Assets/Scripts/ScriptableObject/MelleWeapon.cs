using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapon/Melee Weapon", fileName = "New Melee Weapon")]
public class MelleWeapon : Weapon
{
    [SerializeField]private int _damage;
    [SerializeField] private float _fireRate;
    [SerializeField] private AudioClip _shotSound;

    public override void Attack()
    {
        
    }

    public override int Damage { get => _damage; }
    public override float FireRate { get => _fireRate; }
    public override AudioClip ShotSound { get => _shotSound; }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapon/Gun1 Weapon", fileName = "New Gun Weapon")]
public class GunItem : Weapon, IGun
{
    [SerializeField] private int _damage; // Weapon
    [SerializeField] private float _fireRate;
    [SerializeField] private AudioClip _shotSound;

    [SerializeField] private AmmunitionItem _ammo; // IGun
    [SerializeField] private int _magazineSize;
    [SerializeField] private float _timeReload;


    public override int Damage { get => _damage; }
    public override float FireRate { get => _fireRate; }
    public override AudioClip ShotSound { get => _shotSound; }



    //IGun
    public AmmunitionItem Ammo { get => _ammo; }
    public int MagazineSize { get => _magazineSize; }
    public float TimeReload { get => _timeReload; }

 
}

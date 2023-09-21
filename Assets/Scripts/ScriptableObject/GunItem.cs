using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapon/Gun Weapon", fileName = "New Gun Weapon")]
public class GunItem : ScriptableObject, IGun
{
    [SerializeField] private int _damage;
    [SerializeField] private float _fireRate;
    [SerializeField] private AudioClip _shotSound;
    //[SerializeField] private string _name;
    //[SerializeField] private string _description;
    //[SerializeField] private Texture2D _icon;
    //[SerializeField] private bool _isStored;
    [SerializeField] private IAmmunition _ammo;
    [SerializeField] private Item _itemAsset;


    public int Damage { get => _damage; }
    public float FireRate { get => _fireRate; }
    public AudioClip ShotSound { get => _shotSound; }
    //public string Name { get => _name; }
    //public string Description { get => _description; }
    //public Texture2D Icon { get => _icon; }
    //public bool IsStored { get => _isStored; }
    public IAmmunition ammo { get => _ammo; }

    public Item ItemAsset { get => _itemAsset; }
}

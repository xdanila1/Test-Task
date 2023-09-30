using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapon/Ammo", fileName = "New Ammo")]
public class AmmunitionItem : Item, IAmmunition
{

    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isStored;
    [SerializeField] private float _damageBullet;


    public override string Name { get => _name; }
    public override string Description { get => _description; }
    public override Sprite Icon { get => _icon; }
    public override bool IsStored { get => _isStored; }
    public float DamageBullet  {get => _damageBullet;}
}

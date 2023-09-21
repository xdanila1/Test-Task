using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapon/Ammo", fileName = "New Ammo")]
public class AmmunitionItem : ScriptableObject, IAmmunition
{

    //[SerializeField] private string _name;    // duplicate code contentItem :(
    //[SerializeField] private string _description;
    //[SerializeField] private Texture2D _icon;
    //[SerializeField] private bool _isStored;
    [SerializeField] private float _damageBullet;
    [SerializeField] private Item _itemAsset;


    //public string Name { get => _name; }
    //public string Description { get => _description; }
    //public Texture2D Icon { get => _icon; }
    //public bool IsStored { get => _isStored; }
    public float DamageBullet  {get => _damageBullet;}
    public Item ItemAsset { get =>_itemAsset; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Weapon : Item
{

    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isStored;

    public abstract int Damage { get; }
    public abstract float FireRate { get; }
    public abstract AudioClip ShotSound { get; }


    public override string Name { get => _name; }
    public override string Description { get => _description; }
    public override Sprite Icon { get => _icon; }
    public override bool IsStored { get => _isStored; }
}

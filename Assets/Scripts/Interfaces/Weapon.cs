using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Weapon : ScriptableObject, IItem // надо бы и предмет наследовать от SO...
{

    // Weapon
    public abstract int Damage { get; }
    public abstract float FireRate { get; }
    public abstract AudioClip ShotSound { get; }

    public abstract void Attack();

    // Item

    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isStored;

    public string Name { get => _name; }
    public string Description { get => _description; }
    public Sprite Icon { get => _icon; }
    public bool IsStored { get => _isStored; }
}

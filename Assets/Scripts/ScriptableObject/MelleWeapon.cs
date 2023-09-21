using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapon/Melee Weapon", fileName = "New Melee Weapon")]
public class MelleWeapon : ScriptableObject, IWeapon
{
    [SerializeField]private int _damage;
    [SerializeField] private float _fireRate;
    [SerializeField] private AudioClip _shotSound;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isStored;


    public int Damage { get => _damage; }
    public float FireRate { get => _fireRate; }
    public AudioClip ShotSound { get => _shotSound; }
    public string Name { get => _name; }
    public string Description { get => _description; }
    public Sprite Icon { get => _icon; }
    public bool IsStored { get => _isStored; }
}
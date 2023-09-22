using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour, IPickable, IDamagble
{
    [Header("Inventory")]
    [SerializeField] private Inventory _inventory;
    [Space(5)]

    [Header("Health")]
    [Range(1,150)]
    [SerializeField] private int _maxHealth=100;
    [SerializeField] private int _HP;
    [Space(5)]

    [Header("Other")]
    [SerializeField] private int _money;   // why not



    public int HP { get => _HP; }
    public Inventory Inventory { get => _inventory; }

    public bool Overflowing { get => Inventory.Overflowing; }

    private void OnValidate()
    {
        _HP = Mathf.Clamp(_HP, 0, _maxHealth);
        _money = Mathf.Clamp(_money, 0, _money );
    }

    public void PickUp(IItem item, int count)
    {
        if (!item.IsStored) count = 1;
        if(!Inventory.Overflowing)
        {
            _inventory.AddItem(item,count);
            return;
        }
            print("Инвентарь переполнен");
    }
    
    public void TakeDamage(int damage)
    {
        // check for zero
        _HP -= damage;
    }
}

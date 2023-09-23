using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerData : MonoBehaviour, IPickable, IDamagble
{
    [Header("Inventory")]
    [SerializeField] private Inventory _inventory;
    [Space(5)]

    [Header("Health")]
    [Range(1,150)]
    [SerializeField] private int _maxHealth=100;
    [SerializeField] private int _HP;
    public MyUnityEvent OnHealthChange;
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
        print($"Игрок подобрал {item.Name}");
        if (!item.IsStored) count = 1;
        if(!Inventory.Overflowing)
        {
            _inventory.AddItem(item,count);
            return;
        }
            print("Инвентарь переполнен");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) TakeDamage(10);
    }
    public void TakeDamage(int damage)
    {
        if (damage <= 0) damage *= -1;
        _HP -= damage;
        OnHealthChange.Invoke((float)_HP/_maxHealth);
    }
}

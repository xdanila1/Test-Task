using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectorSystem : MonoBehaviour, IPickable
{
    [Header("Inventory")]
    [SerializeField] private Inventory _inventory;

    public Inventory Inventory { get => _inventory; }
    public bool Overflowing { get => Inventory.Overflowing; }


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


}

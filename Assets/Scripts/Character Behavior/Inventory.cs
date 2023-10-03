using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private InventoryCell[] _cellsInventory;
    

    public Action<Item> onItemAdded;
    private bool _inventoryOverflowing;
    public bool Overflowing { get => _inventoryOverflowing; }

    //private List<IItem> _items;
    //void OnValidate()
    //{
    //    _items = new List<IItem>();
    //   if(_Assets!=null) for (int i = 0; i < _Assets.Count; i++)
    //    {
    //        var asset = _Assets[i];
    //        if (!(asset is IItem item)) Debug.LogError("В инвентарь помещен не игровой предмет");
    //        else _items.Add(item);
    //    }


    //}
    private void Start()
    {
        InitializingCells();
        //RenderInventory(_items);
    }
    //public void RenderInventory(InventoryCell[] cells)
    //{
    //    foreach (var item in cells)
    //    {
    //        if(!item.isEmpty)   item.RenderItem(item.Item, item.Count);
    //    }
    //}
    public void InitializingCells()
    {
        for(int i=0;i<_cellsInventory.Length;i++)
        {
            _cellsInventory[i].IdCell = i;
        }
    }

    public void AddItem(Item item, int count)
    {
        int idEmptyCell=-1;
        print($"В инвентарь добавлено {item.Name} в количестве {count} штук(и)");

        for (int i = 0; i < _cellsInventory.Length; i++)
        {
            if (_cellsInventory[i].isEmpty && idEmptyCell<0) idEmptyCell = i;

            if(_cellsInventory[i].Item == item && _cellsInventory[i].Item.IsStored)
            {
                //check overflowing
                _cellsInventory[i].RenderItem(item, count);
                return;
            }
            if(i==_cellsInventory.Length-1 && idEmptyCell>=0)
            {
                _cellsInventory[idEmptyCell].RenderItem(item, count);
            }
        }
        if (idEmptyCell < 0) _inventoryOverflowing = true;
        onItemAdded?.Invoke(item);
    }
    
    public void DeselectCell()
    {
        foreach (var cell in _cellsInventory)
        {
            cell.Deselect();
        }
    }
}

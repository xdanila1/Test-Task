using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InventoryCell _CellTemplate;
    [SerializeField] private Transform _container;
    [SerializeField] private List<ScriptableObject> _Assets;

    public Action<IItem> onItemAdded;

    private List<IItem> _items;
    void Start()
    {
        _items = new List<IItem>();
        for (int i = 0; i < _Assets.Count; i++)
        {
            var asset = _Assets[i];
            if (!(asset is IItem item)) Debug.LogError("В инвентарь помещен не игровой предмет");
            else _items.Add(item);
        }
        Render(_items);

    }
    public void Render(List<IItem> items)
    {
        foreach (IItem item in items)
        {
            var cell = Instantiate(_CellTemplate, _container);
            cell.RenderItem(item);
        }
    }

    public void AddItem(IItem item, int count)
    {
        print($"В инвентарь добавлено {item.Name} в количестве {count} штук(и)");
        for (int i = 0; i < count; i++)
        {
            _items.Add(item);
            onItemAdded?.Invoke(item);
        }
    }
}

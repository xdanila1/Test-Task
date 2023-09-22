using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InventoryCell : MonoBehaviour
{
    [Header("Item Info")]
    [SerializeField] Image _imageUI;
    [SerializeField] private int _count;
    [Space(10)]

    [Header("Cells Info")]
    [SerializeField] TextMeshProUGUI _countUI;
    [SerializeField] int _idCell;
    [SerializeField] bool _overflowing; // max count 64
    [SerializeField] bool _isEmpty =true;

    public IItem Item { get => _item;}
    public bool isEmpty{ get => _isEmpty;}
    public int Count { get => _count; }

    private IItem _item;

    public void RenderItem(IItem item, int count)
    {
        print("Render Item");
        if(item.IsStored)
        {
            print("wtwt");
            _countUI.enabled = true;
            if(!_isEmpty)
            {
                print("ќбновление данных €чейки");
                _count += count;
                _countUI.text = _count + "";
                return;
            }
        }
        print("«аполнение данных €чейки");
        _item = item;
        _imageUI.sprite = item.Icon;
        _imageUI.enabled = true;
        _countUI.text = count+"";
        _count = count;
        _isEmpty = false;
    }

}

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
    [SerializeField] bool _overflowing;
    [SerializeField] bool _isEmpty =true;
    [SerializeField] Image _selectIcon;

    [SerializeField]private Item _item;

    public int IdCell { get; set; }
    public Item Item { get => _item;}
    public bool isEmpty{ get => _isEmpty;}
    public int Count { get => _count; }


    public void RenderItem(Item item, int count)
    {
        print("Render Item");
        if(item.IsStored)
        {
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
    public void DeleteCell()
    {
        _isEmpty = true;
        _imageUI.enabled = false;
        _countUI.enabled = false;
    }

    public void Select()
    {
        _selectIcon.enabled = true;
    }
    public void Deselect()
    {
        _selectIcon.enabled = false;
    }
}

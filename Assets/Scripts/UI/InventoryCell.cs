using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InventoryCell : MonoBehaviour, IDropHandler
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

    private GameObject _dragObject;

    public int IdCell { get; set; }
    public Item Item { get => _item;}
    public bool isEmpty{ get => _isEmpty;}
    public int Count { get => _count; }


    public void RenderItem(Item item, int count)
    {
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

    public void OnDrop(PointerEventData eventData)
    {
        if (!_isEmpty) return;
        DragAndDropCell dropcell = eventData.pointerDrag.GetComponent<DragAndDropCell>();
        if (dropcell.Cell.isEmpty) return;
        RenderItem(dropcell.Cell.Item, dropcell.Cell.Count);
        dropcell.Cell.DeleteCell();
    }
}

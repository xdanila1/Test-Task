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

    private GameObject _dragObject;

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
                print("Обновление данных ячейки");
                _count += count;
                _countUI.text = _count + "";
                return;
            }
        }
        print("Заполнение данных ячейки");
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
    public void CreateDragIcon()
    {
        print("Создался объект");
        _dragObject = new GameObject("DragObject");
        _dragObject.transform.SetParent(transform.root);
        _dragObject.transform.SetAsLastSibling();
        if (!isEmpty) _dragObject.AddComponent<Image>().sprite = Item.Icon;
    }
    public void Drag()
    {

        print($"Drag: {_dragObject}");
        _dragObject.transform.position = Input.mousePosition;

    }
    public void test2()
    {
        Destroy(_dragObject);
        _dragObject = null;
        print($"Отпустил на объекте: {gameObject.name}");
    }
}

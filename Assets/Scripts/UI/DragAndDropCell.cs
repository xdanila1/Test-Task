using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDropCell : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform _currentParent;
    private Image _image;
    private InventoryCell _cell;

    public InventoryCell Cell { get => _cell; }
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        _image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;

    }
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(_currentParent);
        transform.localPosition = Vector3.zero;
        _image.raycastTarget = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        _cell = GetComponentInParent<InventoryCell>();
        _currentParent = transform.parent;
        _image = GetComponent<Image>();
    }
}

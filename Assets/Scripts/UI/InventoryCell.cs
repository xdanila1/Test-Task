using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryCell : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] TextMeshProUGUI _count;
    [SerializeField] int _idCell;
    void Start()
    {
        
    }
    public void RenderItem(IItem item)
    {
        _image.sprite = item.Icon;
    }

}

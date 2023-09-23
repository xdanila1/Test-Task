using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DescriptionPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _descriptionField;
    [SerializeField] private TextMeshProUGUI _nameField;
    [SerializeField] private Image _iconField;
    [SerializeField] private Button _DeleteButton;

    private InventoryCell _SelectCell;

    public void RenderDescription(InventoryCell cell)
    {
        if (cell.isEmpty)
        {
            ClearDescription();
            return;
        }
        _SelectCell = cell;
        _DeleteButton.interactable = true;
        _nameField.text = cell.Item.Name;
        print($"Name: {cell.Item.Name}");
        _descriptionField.text = cell.Item.Description;
        _iconField.sprite = cell.Item.Icon;

        _nameField.enabled = true;
        _descriptionField.enabled = true;
        _iconField.enabled = true;
    }
    public void DeleteItem()
    {
        if (_SelectCell == null) return;
        _SelectCell.DeleteCell();
        ClearDescription();
    }
    public void ClearDescription()
    {
        _DeleteButton.interactable = false;
        _nameField.enabled = false;
        _descriptionField.enabled = false;
        _iconField.enabled = false;
        _SelectCell = null;
    }
    
}

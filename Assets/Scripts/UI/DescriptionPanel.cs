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

    public void RenderDescription(InventoryCell cell)
    {
        _nameField.text = cell.Item.Name;
        _descriptionField.text = cell.Item.Description;
        _iconField.sprite = cell.Item.Icon;

        _nameField.enabled = true;
        _descriptionField.enabled = true;
        _iconField.enabled = true;
    }
}

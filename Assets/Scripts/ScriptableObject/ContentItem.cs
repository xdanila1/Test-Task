using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Items/Simple item", fileName = "New simple item")]
public class ContentItem : ScriptableObject, IItem
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isStored;


    public string Name { get; }
    public string Description { get => _description; }
    public Sprite Icon { get => _icon; }
    public bool IsStored {get =>_isStored;}

}

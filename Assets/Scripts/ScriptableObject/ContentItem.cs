using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Items/Simple item", fileName = "New simple item")]
public class ContentItem :  Item
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isStored;


    public override string Name { get => _name; }
    public override string Description { get => _description; }
    public override Sprite Icon { get => _icon; }
    public override bool IsStored {get =>_isStored;}

}

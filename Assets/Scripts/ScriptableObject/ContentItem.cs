using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Items/Simple item", fileName = "New simple item")]
public class ContentItem :  Item
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Texture2D _icon;
    [SerializeField] private bool _isStored;


    public override string Name { get; }

    public string Description { get => _description; }
    public Texture2D Icon { get => _icon; }
    public bool IsStored {get =>_isStored;}

}

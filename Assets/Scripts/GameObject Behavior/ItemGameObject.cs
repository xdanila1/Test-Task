using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer))]
public class ItemGameObject : MonoBehaviour
{
    [SerializeField] private Item _item;
    [SerializeField] private int _count=1;

    private SpriteRenderer _sprite;

    public Item Item { get=> _item; set=> _item= value; } 
    public int Count { get =>_count; set=> _count=value; }

    private void OnValidate()
    {
        if (_sprite == null) return;

        _sprite = GetComponent<SpriteRenderer>();
        _sprite.sprite = _item.Icon;
    }

    private void Start()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        _sprite = GetComponent<SpriteRenderer>();
        _sprite.sprite = _item.Icon;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collector = collision.gameObject.GetComponent<IPickable>();
        if (collector != null && !collector.Overflowing) collector.PickUp(_item, _count);
        else return;
        Destroy(this.gameObject);
    }

}

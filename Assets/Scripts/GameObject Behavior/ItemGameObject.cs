using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer))]
public class ItemGameObject : MonoBehaviour
{
    [SerializeField] private ScriptableObject _asset;
    [SerializeField] private int count=1;

    private SpriteRenderer _sprite;
    private IItem _item;

    private void OnValidate()
    {
        if (!(_asset is IItem asset)) Debug.LogError("������������ ������ �� �������� ������� ���������");
        else _item = (IItem)_asset;
        _sprite = GetComponent<SpriteRenderer>();
        _sprite.sprite = _item.Icon;
        if (!_item.IsStored && count != 1) Debug.LogWarning("������� �� ������������ ������������� ����");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject);
        var collector = collision.gameObject.GetComponent<IPickable>();
        if (collector != null && !collector.Overflowing) collector.PickUp(_item, count);
        else return;
        Destroy(this.gameObject);
    }

}
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

    private void Start()
    {
        if (!(_asset is IItem asset)) Debug.LogError("Передаваемый объект является предметом");
        else _item = (IItem)_asset;

        if (!_item.IsStored && count != 1) Debug.LogWarning("Предмет не поддерживает множественный стак");

        _sprite = GetComponent<SpriteRenderer>();
        _sprite.sprite = _item.Icon;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collector = collision.gameObject.GetComponent<Inventory>();
        print(collector);
        if (collector != null) collector.AddItem(_item, count);
        else return;
        Destroy(this.gameObject);
    }

}

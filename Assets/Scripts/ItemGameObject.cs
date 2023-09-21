using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer))]
public class ItemGameObject : MonoBehaviour
{
    [SerializeField,SerializeReference]
     IItem _item;

    private SpriteRenderer _sprite;

    void Start()
    {

        //if (_sprite.sprite != _item.Icon) Debug.LogWarning("Спрайт и передаваемый объект не совпадают");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collector = collision.gameObject.GetComponent<Inventory>();
        //if (collector != null) collector.AddItem(_item);
        Destroy(this.gameObject);
    }

}

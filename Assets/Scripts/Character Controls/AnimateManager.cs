using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateManager : MonoBehaviour
{
    [Header("Joystick")]
    [SerializeField] private Joystick _joystick;
    [Header("Sprite")]
    [SerializeField] private SpriteRenderer _sprite;
    [Header("Animator")]
    [SerializeField] private Animator _anim;

    private Vector2 _direction; // ѕо хорошему надо добавить в сам класс Joystick

    private void FixedUpdate()
    {

    }

    void Update()
    {
        Animate();
    }

    private void Animate()
    {
        if(_joystick.Horizontal!=0) _sprite.flipX = true ? _joystick.Horizontal<0 : false;
        /*
         * if(_joystick.Horizontal<0) _sprite.fliX = true
         * else _sprite.flipX = false
         */

        _direction = new Vector2(_joystick.Horizontal, _joystick.Vertical);
        _anim.SetFloat("Speed", _direction.magnitude);
    }

}

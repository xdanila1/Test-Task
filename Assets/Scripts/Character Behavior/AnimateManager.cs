using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateManager : MonoBehaviour
{
    [Header("Joystick")]
    [SerializeField] private Joystick _joystick;
    [Header("Sprite")]
    //[SerializeField] private SpriteRenderer _sprite;
    //[SerializeField] private SpriteRenderer _weapon;
    [SerializeField] private Transform _spriteTransform;
    [Header("Animator")]
    [SerializeField] private Animator _anim;

    private Vector2 _direction; // �� �������� ���� �������� � ��� ����� Joystick
    private Vector3 _scaleObject;


    private void Start()
    {
        _scaleObject = _spriteTransform.localScale;
    }
    public void AnimateAttack()
    {
        
    }

    void Update()
    {
        Animate();
    }

    private void Animate()
    {
        if (_joystick.Horizontal != 0)
        {
            if (_joystick.Horizontal < 0)
            {
                //_sprite.flipX = true; ��� ������� �� ������������ �������������� �������, ��-�� ���� �������� �������� ��������(������) ����������
                //if(_weapon != null)_weapon.flipY = true;  
                _scaleObject.x = -1;
                _spriteTransform.localScale = _scaleObject;
            }
            else
            {
                //_sprite.flipX = false;
                //if(_weapon !=null) _weapon.flipY = false;
                _scaleObject.x = 1;
                _spriteTransform.localScale = _scaleObject;
            }
        }



        _direction = new Vector2(_joystick.Horizontal, _joystick.Vertical);
        _anim.SetFloat("Speed", _direction.magnitude);
    }

}

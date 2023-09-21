using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("JoyStick")]
    [SerializeField] private Joystick _joystick;
    [Header("Speed")]
    [SerializeField] private float _moveSpeed;

    private Rigidbody2D _rig;
    private Vector2 _direction;

    public float Speed { get => _moveSpeed;}


    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetInput();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rig.MovePosition(_rig.position+_moveSpeed*_direction*Time.deltaTime);
    }
    private void GetInput()
    {
        _direction = new Vector2(_joystick.Horizontal, _joystick.Vertical);
    }
}

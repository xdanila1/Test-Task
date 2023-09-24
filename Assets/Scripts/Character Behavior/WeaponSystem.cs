using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private SpriteRenderer _SpriteWeapon;
    [SerializeField] private float _rangeAttack;
    [SerializeField] private AudioSource _shotSound;
    [SerializeField] LayerMask _layerEnemy;

    private Transform _target;
    private float _cooldown;

    public UnityEvent OnAttack;



    public void AttackWeapon()
    {
        //if (_target == null) return;
        if (Time.time < _cooldown) return;

        _shotSound.pitch = Random.Range(0.9f, 1f);
        _cooldown = Time.time + 1f / _weapon.FireRate; // скорострельность в секунду
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, _rangeAttack, _layerEnemy.value);
        foreach (var obj in objects)
        {
            print(obj.name);
            IDamagble enemy = obj.GetComponent<IDamagble>();
            if (enemy != null)
            {
                Debug.DrawLine(transform.position, obj.transform.position, Color.green, 1f);
                print(enemy);
                enemy.TakeDamage(_weapon.Damage);
                print($"Удар {_weapon.name} по {obj.name}");
                OnAttack.Invoke();
                return;
            }
        }

    }
    private void Start()
    {
        _shotSound.clip = _weapon.ShotSound;
        _cooldown = Time.time;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space)) AttackWeapon();
    }

    private void Shoot()
    {

    }
}

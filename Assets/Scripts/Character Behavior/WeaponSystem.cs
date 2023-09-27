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
    [SerializeField] private LayerMask _layerEnemy;

    private float _cooldown;
    private HealthSystem _target;

    public UnityEvent OnAttack;

    public void PressAttack()
    {
        InvokeRepeating("AttackWeapon", 0, 0.05f);
    }
    public void StopAttack()
    {
        CancelInvoke("AttackWeapon");
    }

    public void AttackWeapon()
    {
        //if (_target == null) return;
        if (Time.time < _cooldown) return;

        _shotSound.pitch = Random.Range(0.9f, 1f);
        _cooldown = Time.time + 1f / _weapon.FireRate; // скорострельность в секунду

        HealthSystem test;
        test = FindEnemy();
        print(FindEnemy());
        print(test);
        if(_target==null) _target = FindEnemy();
        else
        {
            print("Атака на :"+_target);
            _target.TakeDamage(_weapon.Damage);
            if (_target.IsDead) _target = null;
            OnAttack.Invoke();
        }
        print(_target);
    }

    private HealthSystem FindEnemy()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, _rangeAttack, _layerEnemy.value);
        foreach (var obj in objects)
        {
            HealthSystem enemy = obj.GetComponent<HealthSystem>();
            print("Возвращаю:" + enemy);
            if (enemy != null && !enemy.IsDead)
            {
                Debug.DrawLine(transform.position, obj.transform.position, Color.green, 1f);
                print("Возвращаю:" + enemy);
                return enemy;
            }
        }
            return null;
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

}

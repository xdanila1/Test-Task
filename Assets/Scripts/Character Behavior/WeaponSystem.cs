using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private SpriteRenderer _SpriteWeapon;
    [SerializeField] private float _rangeAttack;
    [SerializeField] private AudioSource _shotSound;
    [SerializeField] private LayerMask _layerEnemy;
    [SerializeField] private TextMeshProUGUI _magazineUI;


    private float _delayFiring;
    private float _delayReload;
    private float _timeToReload;
    private HealthSystem _target;
    private int _magazineSize;
    private int _currentMagazine;
    private bool _isAutoMode; // current state

    public UnityEvent OnAttack;
    public UnityEvent OnReload;
    public MyWeaponUnityEvent OnChange;

    public void Reload()
    {
        if (Time.time < _delayReload) return;
        _currentMagazine = _magazineSize;
        _magazineUI.text = $"{_currentMagazine}/{_magazineSize}";
        _delayReload = Time.time+_timeToReload;
        print($"Время:{Time.time}  Время когда можно стрелять {_delayReload}");
        OnReload.Invoke();
    }
    public void SetWeaponMode(bool isAuto)
    {
        _isAutoMode = isAuto;
    }
    public void PressAttack()
    {
        print("Зажата атака");
        if (!_isAutoMode) return;
        InvokeRepeating("AttackWeapon", 0, 0.05f);
    }
    public void StopAttack()
    {
        CancelInvoke("AttackWeapon");
    }

    public void AttackWeapon()
    {
        print("Атака");
        //if (_target == null) return;
        if (Time.time < _delayFiring) return;
        if (Time.time < _delayReload) return;

        _shotSound.pitch = Random.Range(0.9f, 1f);
        _delayFiring = Time.time + 1f / _weapon.FireRate; // скорострельность в секунду
        if(_currentMagazine<=0)
        {
            Reload();
            return;
        }


        if(_target==null) _target = FindEnemy();
        else
        {
            if (_target.IsDead || Vector2.Distance(_target.transform.position,transform.position) > _rangeAttack)
            {
                _target = null;
                return;
            }
            
            print("Атака на :"+_target);
            _target.TakeDamage(_weapon.Damage);
            _currentMagazine--;
            _magazineUI.text = $"{_currentMagazine}/{_magazineSize}";
            OnAttack.Invoke();
        }
    }

    private HealthSystem FindEnemy()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, _rangeAttack, _layerEnemy.value);
        foreach (var obj in objects)
        {
            HealthSystem enemy = obj.GetComponent<HealthSystem>();
            if (enemy != null && !enemy.IsDead)
            {
                Debug.DrawLine(transform.position, obj.transform.position, Color.green, 1f);
                return enemy;
            }
        }
            return null;
    }

    private void Start()
    {
        _shotSound.clip = _weapon.ShotSound;
        _delayFiring = Time.time;
        if (_weapon is GunItem gun)
        {
            _magazineSize = gun.MagazineSize;
            _currentMagazine = _magazineSize;
            _timeToReload = gun.TimeReload;
        }
        else _currentMagazine = 1; // if use melee weapon
        OnChange.Invoke(_weapon);
    }

}

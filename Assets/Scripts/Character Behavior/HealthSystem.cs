using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour, IDamagble
{
    [Header("Health Value")]
    [Range(1, 150)]
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _HP;

    private bool _isDead=false;

    public MyFloatUnityEvent OnHealthChange;
    public UnityEvent OnDead;
    public int HP { get => _HP; }
    public bool IsDead { get => _isDead; }


    private void OnValidate()
    {
        _HP = Mathf.Clamp(_HP, 0, _maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (_isDead) return;
        if (damage <= 0) damage *= -1;
        _HP -= damage;
        OnHealthChange.Invoke((float)_HP / _maxHealth);

        if (_HP <= 0)
        {
            OnDead.Invoke();
            _isDead=true;
        }
    }

}

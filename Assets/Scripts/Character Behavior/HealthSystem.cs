using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour, IDamagble
{
    [Header("Health Value")]
    [Range(1, 150)]
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _HP;

    public MyUnityEvent OnHealthChange;
    public int HP { get => _HP; }

    private void OnValidate()
    {
        _HP = Mathf.Clamp(_HP, 0, _maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0) damage *= -1;
        _HP -= damage;
        OnHealthChange.Invoke((float)_HP / _maxHealth);
    }

}

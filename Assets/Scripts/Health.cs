using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;

    private float _currentHealth;

    public float CurrentHealth => _currentHealth;
    public float MaxHealth => _maxHealth;

    public event UnityAction<float> HealthChanged;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void Heal(float addedHealth)
    {
        _currentHealth = Mathf.Clamp(_currentHealth += addedHealth, 0, _maxHealth);
        HealthChanged?.Invoke(_currentHealth / _maxHealth);
    }

    public void ApplyDamage(float damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth -= damage, 0, _maxHealth);
        HealthChanged?.Invoke(_currentHealth / _maxHealth);
    }
}

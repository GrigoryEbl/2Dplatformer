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
        float targetHealth = _currentHealth += addedHealth;

        _currentHealth = Mathf.Clamp(targetHealth, 0, _maxHealth);

        Die();
        HealthChanged?.Invoke(_currentHealth / _maxHealth);
    }

    public void ApplyDamage(float damage)
    {
        float targetHealth = _currentHealth -= damage;

        _currentHealth = Mathf.Clamp(targetHealth, 0, _maxHealth);

        Die();
        HealthChanged?.Invoke(_currentHealth / _maxHealth);
    }

    private void Die()
    {
        if (_currentHealth <= 0)
            gameObject.SetActive(false);
    }
}

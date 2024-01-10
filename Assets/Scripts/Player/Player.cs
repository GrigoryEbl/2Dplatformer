using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Attack))]
public class Player : MonoBehaviour
{
    
    [SerializeField] private float _maxHealth = 100f;

    private float _health;
    private Attack _attack;

    public float Health => _health;
    public float MaxHealth => _maxHealth;

    public event UnityAction<float> HealthChanged;

    private void Awake()
    {
        _health = _maxHealth;
        _attack = GetComponent<Attack>();
    }

    public void Heal(float addedHealth)
    {
        _health = Mathf.Clamp(_health += addedHealth, 0, _maxHealth);

        HealthChanged?.Invoke(_health / _maxHealth);

    }

    public void ApplyDamage(float damage)
    {
        _health = Mathf.Clamp(_health -= damage, 0, _maxHealth);
        HealthChanged?.Invoke(_health / _maxHealth);

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Enemy enemy))
        {
            _attack.TakeDamage(enemy);
        }
    }
}

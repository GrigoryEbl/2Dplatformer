using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attack))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private HealthBar _healthBar;

    private float _currentHealth;
    private Attack _attack;

    public float Health => _currentHealth;
    public float MaxHealth => _maxHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _attack = GetComponent<Attack>();
    }

    private void Update()
    {
        print("Player health: " + _currentHealth);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Enemy enemy))
        {
           _attack.TakeDamage(enemy);
        }
    }

    public void Heal(float addedHealth)
    {
        if (_currentHealth + addedHealth >= _maxHealth)
            _currentHealth = _maxHealth;
        else
            _currentHealth += addedHealth;

        _healthBar.ChangeHealth();
    }

    public void ApplyDamage(float damage)
    {
        _currentHealth -= damage;
        _healthBar.ChangeHealth();
    }
}

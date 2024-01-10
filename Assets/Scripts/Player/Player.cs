using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attack))]
public class Player : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private float _maxHealth = 100f;

    private float _health;
    private Attack _attack;

    public float Health => _health;
    public float MaxHealth => _maxHealth;

    private void Awake()
    {
        _healthBar = FindAnyObjectByType<HealthBar>();
        _health = _maxHealth;
        _attack = GetComponent<Attack>();
    }

    public void Heal(float addedHealth)
    {
        _health = Mathf.Clamp(_health += addedHealth, 0, _maxHealth);
        _healthBar.StartCoroutine(_healthBar.ChangeHealth(_health / _maxHealth));
    }

    public void ApplyDamage(float damage)
    {
        _health = Mathf.Clamp(_health -= damage, 0, _maxHealth);
        _healthBar.StartCoroutine(_healthBar.ChangeHealth(_health / _maxHealth));
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Enemy enemy))
        {
            _attack.TakeDamage(enemy);
        }
    }
}

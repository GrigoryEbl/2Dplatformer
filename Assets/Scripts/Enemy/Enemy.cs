using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attack))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 30f;

    private float _health;
    private Attack _attack;

    private void Awake()
    {
        _attack = GetComponent<Attack>();
        _health = _maxHealth;
    }

    public void ApplyDamage(float damage)
    {
        _health = Mathf.Clamp(_health -= damage, 0, _maxHealth);

        if (_health <= 0)
            Die();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            _attack.TakeDamage(player);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}

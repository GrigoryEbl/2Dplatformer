using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _delay;
    [SerializeField] private float _maxHealth = 100f;

    private float _health;
    private float _lastAttackTime;

    private void Awake()
    {
        _health = _maxHealth;
    }

    private void Update()
    {
        _lastAttackTime -= Time.deltaTime;
        print("Player health: " + _health);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Enemy enemy))
        {
            if (Vector2.Distance(transform.position, enemy.transform.position) <= _attackDistance)
            {
                if (_lastAttackTime <= 0)
                {
                    Attack(enemy);
                    _lastAttackTime = _delay;
                }
            }
        }
    }

    private void Attack(Enemy enemy)
    {
        enemy.ApplyDamage(_damage);
    }

    public void ApplyDamage(float damage)
    {
        _health -= damage;
    }

    internal void Heal(float addedHealth)
    {
        if (_health + addedHealth >= _maxHealth)
            _health = _maxHealth;
        else
            _health += addedHealth;
    }
}

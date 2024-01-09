using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _delay;
    [SerializeField] private float _health = 100f;

    private float _lastAttackTime;

    private void Update()
    {
        _lastAttackTime -= Time.deltaTime;
        print($"{name} health: " + _health);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            if (Vector2.Distance(transform.position, player.transform.position) <= _attackDistance)
            {
                if (_lastAttackTime <= 0)
                {
                    Attack(player);
                    _lastAttackTime = _delay;
                }
            }
        }
    }

    private void Attack(Player target)
    {
        target.ApplyDamage(_damage);
    }

    internal void ApplyDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}

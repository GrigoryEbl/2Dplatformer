using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health = 100f;

    private Attack _attack;

    private void Awake()
    {
        _attack = GetComponent<Attack>();
    }

    private void Update()
    {
        print($"{name} health: " + _health);
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

    public void ApplyDamage(float damage)
    {
        _health -= damage;

        //if (_health <= 0)
        //  //Die();
    }
}

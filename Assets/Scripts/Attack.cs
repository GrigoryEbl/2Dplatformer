using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _damage;
    [SerializeField] private float _delay;

    private float _lastAttackTime;

    private void Awake()
    {
        _lastAttackTime = _delay;
    }

    private void Update()
    {
        _lastAttackTime -= Time.deltaTime;
    }

    public void TakeDamage(Health target)
    {
        if (Vector2.Distance(transform.position, target.transform.position) <= _attackDistance)
        {
            if (_lastAttackTime <= 0)
            {
                target.ApplyDamage(_damage);
                _lastAttackTime = _delay;
            }
        }
    }

    //public void TakeDamage(Player target)
    //{
    //    if (Vector2.Distance(transform.position, target.transform.position) <= _attackDistance)
    //    {
    //        if (_lastAttackTime <= 0)
    //        {
    //            target.ApplyDamage(_damage);
    //            _lastAttackTime = _delay;
    //        }
    //    }
    //}
}

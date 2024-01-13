using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Vampirism : Health
{
    [SerializeField] private Health _target;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _radius;
    [SerializeField] private float _damage;

    private float _waitForSeconds = 1f;
    private Health _playerHealth;
    private float _delay;

    private void Awake()
    {
        _playerHealth = GetComponent<Health>();
    }

    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radius, _enemyLayer);

        FindEnemy(colliders);

        _delay -= Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;

        Gizmos.DrawWireSphere(transform.position, _radius);
    }

    private void FindEnemy(Collider2D[] colliders)
    {
        foreach (Collider2D collider in colliders)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (collider.TryGetComponent<Health>(out Health enemy))
                {
                    StartCoroutine(PullingHealth(enemy));
                    print(enemy.name + ": " + enemy.CurrentHealth);
                }
            }

            break;
        }
    }

    private IEnumerator PullingHealth(Health enemy)
    {
        _delay = 6f;

        while (_delay > 0)
        {
            enemy.ApplyDamage(_damage);
            _playerHealth.Heal(_damage);

            yield return new WaitForSeconds(_waitForSeconds);
        }
    }
}

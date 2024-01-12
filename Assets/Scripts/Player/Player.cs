using UnityEngine;

[RequireComponent(typeof(Attack))]
public class Player : MonoBehaviour
{
    private Attack _attack;

    private void Awake()
    {
        _attack = GetComponent<Attack>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Health health) && collision.collider.TryGetComponent(out Enemy enemy))
        {
            _attack.TakeDamage(health);
        }
    }
}

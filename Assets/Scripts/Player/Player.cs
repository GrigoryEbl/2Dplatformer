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
        if (collision.collider.TryGetComponent(out Health enemy))
        {
            _attack.TakeDamage(enemy);
        }
    }
}

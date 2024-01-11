using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour
{
    [SerializeField] private float _addedHealth = 10f; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Health>(out Health player) && collision.TryGetComponent<Enemy>(out Enemy enemy) == false)
        {
            player.Heal(_addedHealth);
            Destroy(gameObject);
        }
    }
}

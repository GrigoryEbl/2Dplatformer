using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour
{
    [SerializeField] private float _addedHealth = 10f; 

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            player.Heal(_addedHealth);
            Destroy(gameObject);
        }
    }
}

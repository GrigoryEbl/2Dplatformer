using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health = 100f;

    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _health;
    }
}

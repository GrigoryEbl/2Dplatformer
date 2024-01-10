using TMPro;
using UnityEngine;

public class HealthBar2 : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.HealthChanged += OnChangeHealth;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnChangeHealth;
    }

    private void OnChangeHealth(float target)
    {
        _text.text = _player.Health.ToString() + '/' + _player.MaxHealth;
    }
}

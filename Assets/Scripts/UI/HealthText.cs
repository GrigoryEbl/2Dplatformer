using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.HealthChanged += OnChangeText;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnChangeText;
    }

    private void OnChangeText(float target)
    {
        _text.text = _player.Health.ToString() + '/' + _player.MaxHealth;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class HealthBar1 : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;

    private void Start()
    {
        _slider = GetComponentInChildren<Slider>();
        _slider.value = _player.Health / _player.MaxHealth;
    }

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
        _slider.value = target;
    }
}

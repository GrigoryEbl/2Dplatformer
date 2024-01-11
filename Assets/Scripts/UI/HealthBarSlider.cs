using UnityEngine;
using UnityEngine.UI;

public class HealthBarSlider : MonoBehaviour
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
        _player.HealthChanged += OnChangeSlider;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnChangeSlider;
    }

    private void OnChangeSlider(float target)
    {
        _slider.value = target;
    }
}

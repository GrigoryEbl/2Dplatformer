using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBarSlider : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>(); 
        _slider.value = _health.CurrentHealth / _health.MaxHealth;
    }

    private void OnEnable()
    {
        _health.HealthChanged += OnChangeSlider;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnChangeSlider;
    }

    private void OnChangeSlider(float target)
    {
        _slider.value = target;
    }
}

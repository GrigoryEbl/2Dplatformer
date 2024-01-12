using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class HealthText : MonoBehaviour
{
    [SerializeField] private Health _health;

    private TMP_Text _text;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        _text.text = _health.CurrentHealth.ToString() + '/' + _health.MaxHealth;
    }

    private void OnEnable()
    {
        _health.HealthChanged += OnChangeText;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnChangeText;
    }

    private void OnChangeText(float target)
    {
        _text.text = _health.CurrentHealth.ToString() + '/' + _health.MaxHealth.ToString();
    }
}

using TMPro;
using UnityEngine;
 
public class HealthText : MonoBehaviour
{
    private TMP_Text _text;
    [SerializeField] private Health _health;
      
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
        _text.text = _health.CurrentHealth.ToString() + '/' + _health.MaxHealth;
    }
}

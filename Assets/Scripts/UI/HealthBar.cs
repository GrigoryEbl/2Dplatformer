using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Slider _slider;
    private TMP_Text _text;
    private float _time;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _text = GetComponentInChildren<TMP_Text>();

        _slider.value = _health.CurrentHealth / _health.MaxHealth;
        ShowHealth();
    }

    private void OnEnable()
    {
        _health.HealthChanged += OnChangeHealth;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnChangeHealth;
    }

    public IEnumerator ChangeHealth(float target)
    {
        while (_slider.value != target)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, _time * Time.deltaTime);

            yield return null;
        }
    }

    private void OnChangeHealth(float target)
    {
        StartCoroutine(ChangeHealth(target));
        ShowHealth();
    }

    private void ShowHealth()
    {
        _text.text = _health.CurrentHealth.ToString() + '/' + _health.MaxHealth.ToString();
    }
}

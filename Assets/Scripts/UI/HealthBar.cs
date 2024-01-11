using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Player _player;
    [SerializeField] private float _time;

    private void Start()
    {
        _slider = GetComponentInChildren<Slider>();
        ShowHealth();
        _slider.value = _player.Health / _player.MaxHealth;
    }

    public IEnumerator ChangeHealth(float target)
    {
        while (_slider.value != target)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, _time * Time.deltaTime);

            yield return null;
        }
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
        StartCoroutine(ChangeHealth(target));
        ShowHealth();
    }

    private void ShowHealth()
    {
        _text.text = _player.Health.ToString() + '/' + _player.MaxHealth.ToString();
    }
}

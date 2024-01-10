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

    private string _healthPointName = "HP";

    private void Start()
    {
        _slider = GetComponentInChildren<Slider>();
        ShowHealth(_player.Health);
        _slider.value = _player.Health / _player.MaxHealth;
    }

    public void ChangeHealth()
    {
        ShowHealth(_player.Health);

        //while (_slider.value != _player.Health / _player.MaxHealth)
        //{
        //    _slider.value = Mathf.MoveTowards(_slider.value, _player.Health / _player.MaxHealth, _time * Time.deltaTime);
        //}
    }

    //public IEnumerator ChangeHealth()
    //{
    //    ShowHealth(_player.Health);

    //    while (_slider.value != _player.Health / _player.MaxHealth)
    //    {
    //        _slider.value = Mathf.MoveTowards(_slider.value, _player.Health / _player.MaxHealth, _time * Time.deltaTime);
    //        yield return null;
    //    }
    //}

    private void ShowHealth(float value)
    {
        _text.text = value.ToString() + _healthPointName + '/' + _player.MaxHealth;
    }
}

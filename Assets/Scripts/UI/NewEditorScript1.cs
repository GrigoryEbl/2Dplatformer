//using System.Collections;
//using UnityEngine;
//using UnityEngine.UI;

//[RequireComponent(typeof(Slider))]
//[RequireComponent(typeof(Health))]

//public class HealthBarRenderer : MonoBehaviour
//{
//    private Health _health;
//    private float _speed;
//    private Slider _slider;
//    private Coroutine _coroutine;

//    private void Awake()
//    {
//        _slider = GetComponent<Slider>();
//        _health = GetComponent<Health>();
//        _speed = 5;
//    }

//    private void Start()
//    {
//        _slider.value = _health.HealthCount;
//    }

//    private void OnEnable()
//    {
//        _health.Render += Render;
//    }

//    private void OnDisable()
//    {
//        _health.Render -= Render;
//    }

//    private void Render()
//    {
//        if (_coroutine != null)
//            StopCoroutine(_coroutine);

//        _coroutine = StartCoroutine(Updating());
//    }

//    private IEnumerator Updating()
//    {
//        while (_health.HealthCount != _slider.value)
//        {
//            _slider.value = Mathf.MoveTowards(_slider.value, _health.HealthCount, _speed * Time.deltaTime);
//            yield return null;
//        }
//    }
//}


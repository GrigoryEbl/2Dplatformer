using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;
    [SerializeField] private float _positionZ;
    [SerializeField] private float _positionY;

    private Vector3 _target;

    private void Update()
    {
        _target = _player.position;
        _target.z = _positionZ;
        _target.y += _positionY;
        transform.position = Vector3.Lerp(transform.position, _target, _speed * Time.deltaTime);
    }
}

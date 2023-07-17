using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform _path;
    [SerializeField] private bool _faceRight = true;
    [SerializeField] private float _speed;

    private readonly string _walk = "isWalk";
    private Animator _animator;
    private Transform[] _points;
    private int _currentPoint;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }

        _animator = GetComponent<Animator>();
        Animator.StringToHash(_walk);
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.right.x > 0)
        {
            _animator.SetBool(_walk, true);
        }
        else
        {
            _animator.SetBool(_walk, false);
        }

        if (transform.position == target.position)
        {
            _currentPoint++;
            Flip();

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }

    public void Flip()
    {
        _faceRight = !_faceRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}

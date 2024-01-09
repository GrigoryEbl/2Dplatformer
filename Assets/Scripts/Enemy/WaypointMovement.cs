using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Scaner))]

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private bool _isFaceRight = true;
    [SerializeField] private float _speed;
    [SerializeField] private float _boostSpeed;
    [SerializeField] private Player _player;
    [SerializeField] private Transform _rayPoint;

    private readonly string _walk = "isWalk";
    private Animator _animator;
    private Transform[] _points;
    private int _currentPoint;
    private Scaner _scaner;
    private Transform _target;
    private float _currentSpeed;


    private void Start()
    {
        _currentSpeed = _speed;
        _animator = GetComponent<Animator>();
        _scaner = GetComponent<Scaner>();
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        _target = _points[_currentPoint];

        DetectingPlayer();

        transform.position = Vector3.MoveTowards(transform.position, _target.position, _currentSpeed * Time.deltaTime);

        SetNextPoint();
        Flip();
        SetAnimation();
    }

    private void DetectingPlayer()
    {
        if (_scaner.Scan())
        {
            _target = _player.transform;
            _currentSpeed = _boostSpeed;
        }
        else
        {
            _currentSpeed = _speed;
        }
    }

    private void SetNextPoint()
    {
        if (transform.position == _target.position)
        {
            _currentPoint++;
            _currentPoint %= _points.Length;
        }
    }

    private void Flip()
    {
        Vector3 scaler = transform.localScale;

        if (_target.position.x < transform.position.x && _isFaceRight)
        {
            _isFaceRight = !_isFaceRight;
            scaler.x *= -1;
            transform.localScale = scaler;
        }
        else if (_target.position.x > transform.position.x && !_isFaceRight)
        {
            _isFaceRight = !_isFaceRight;
            scaler.x *= -1;
            transform.localScale = scaler;
        }
    }

    private void SetAnimation()
    {
        if (transform.right.x > 0)
            _animator.SetBool(_walk, true);
        else
            _animator.SetBool(_walk, false);
    }
}

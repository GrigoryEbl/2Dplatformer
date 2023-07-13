using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class Mover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _body;
    [SerializeField] private GameObject groundCheckPoint;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float _targetSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private bool _faceRight = true;

    private readonly string _run = "isRun";
    private Animator _animator;
    private float _speed = 0;
    private float groundCheckRadius = 0.2f;
    private bool isGrounded;

    private void Start()
    {
        _body.GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        Animator.StringToHash(_run);
    }

    private void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.transform.position, groundCheckRadius, groundLayer);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D) )
        {
            _speed = _targetSpeed;
            transform.Translate(_targetSpeed * Time.deltaTime, 0, 0);
            _animator.SetBool(_run, true);

            if (Input.GetKey(KeyCode.D) && _faceRight == false)
                Flip();

        }

        if (Input.GetKey(KeyCode.A) )
        {
            _speed = _targetSpeed;
            transform.Translate(_targetSpeed * Time.deltaTime * -1, 0, 0);
            _animator.SetBool(_run, true);

            if (Input.GetKey(KeyCode.A) && _faceRight == true)
                Flip();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _body.velocity = new Vector2(0, _jumpForce);
        }

        if (_speed == 0)
        {
            _animator.SetBool(_run, false);
        }

        _speed = 0;
    }

    public void Flip()
    {
        _faceRight = !_faceRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
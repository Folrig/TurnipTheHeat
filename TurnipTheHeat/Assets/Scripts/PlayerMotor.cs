using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    #region Variables
    private Rigidbody _rigidbody;
    private Vector3 _direction;
    [SerializeField] private float _lastDirection = 0;
    [SerializeField] private float _horizontal;
    [SerializeField] private float _timer;
    [SerializeField] private float _lastJumpTime = 0.0f;
    [SerializeField] private float _wallJumpCooldown = 1.5f;
    [SerializeField] private float _speed = 500.0f;
    [SerializeField] private float _jumpSpeed = 12.0f;
    [SerializeField] private float _wallJumpSpeed = 300.0f;
    [SerializeField] private Transform[] _groundLines;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private LayerMask _wall;
    #endregion

    #region Methods
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
	}
	
    void FixedUpdate()
    {
        _timer += Time.fixedDeltaTime;
        _horizontal = Input.GetAxis("Horizontal");
        bool jump = Input.GetButtonDown("Jump");
        bool isTouchingGround = TouchingGround();
        bool isTouchingWall = TouchingWall();
        bool canWallJump = true;

        if (_timer < _wallJumpCooldown + _lastJumpTime)
        {
            canWallJump = false;
        }

        _horizontal = _horizontal * _speed * Time.fixedDeltaTime;
        _direction = new Vector3(_horizontal, _rigidbody.velocity.y, 0.0f);

        if (_horizontal > 0)
        {
            _lastDirection = 1.0f;
        }
        else if (_horizontal < 0)
        {
            _lastDirection = -1.0f;
        }

        if (jump && isTouchingGround)
        {
            _direction.y = _jumpSpeed;
        }

        else if (canWallJump && jump && isTouchingWall)
        {
            _lastJumpTime = _timer;
            if (_lastDirection == 1.0f)
            {
                _rigidbody.velocity = Vector3.zero;
                _direction.x = -_wallJumpSpeed;
                _direction.y = _jumpSpeed;
            }
            else if (_lastDirection == -1.0f)
            {
                _rigidbody.velocity = Vector3.zero;
                _direction.x = _wallJumpSpeed;
                _direction.y = _jumpSpeed;
            }
        }

        _rigidbody.velocity = _direction;
    }

    private void LateUpdate()
    {
        if (_horizontal > 0)
        {
            _lastDirection = 1.0f;
        }
        else if (_horizontal < 0)
        {
            _lastDirection = -1.0f;
        }
    }

    private bool TouchingGround()
    {
        for (int i = 0; i < _groundLines.Length; i++)
        {
            Vector3 startPoint = new Vector3(_groundLines[i].position.x, _groundLines[i].position.y, 0.0f);
            Vector3 endPoint = new Vector3(_groundLines[i].position.x, _groundLines[i].position.y - 0.2f, 0.0f);
            if (Physics.Linecast(startPoint, endPoint, _ground))
            {
                return true;
            }
        }
        return false;
    }

    private bool TouchingWall()
    {
        for (int i = 0; i < _groundLines.Length; i++)
        {
            Vector3 startPoint = new Vector3(_groundLines[i].position.x, _groundLines[i].position.y, 0.0f);
            Vector3 endPoint;

            if (this._lastDirection > 0)
            {
                endPoint = new Vector3(this._groundLines[i].position.x + 0.15f, this._groundLines[i].position.y, 0.0f);
            }
            else
            {
                endPoint = new Vector3(this._groundLines[i].position.x - 0.15f, this._groundLines[i].position.y, 0.0f);
            }

            if (Physics.Linecast(startPoint, endPoint, _wall))
            {
                return true;
            }
        }
        return false;
    }
    #endregion
}

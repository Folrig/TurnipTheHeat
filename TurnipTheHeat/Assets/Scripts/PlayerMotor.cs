using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    #region Variables
    private Rigidbody _rigidbody;
    private Vector3 _direction;
    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private Transform[] _groundLines;
    [SerializeField] private LayerMask _ground;
    #endregion

    #region Methods
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
	}
	
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        bool jump = Input.GetButtonDown("Jump");
        bool isTouchingGround = TouchingGround();

        horizontal = horizontal * _speed * Time.fixedDeltaTime;
        _direction = new Vector3(horizontal, _rigidbody.velocity.y, 0.0f);

        if (jump && isTouchingGround)
        {
            _direction.y = _jumpSpeed;
        }

        _rigidbody.velocity = _direction;   
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
    #endregion
}

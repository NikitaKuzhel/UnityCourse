using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableSystem : MonoBehaviour
{
    [SerializeField] private JoystickDetector _movable;
    [SerializeField] private float _speed = 12f;
    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] private Animator _animator;

    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 playerVector = _movable.MotionVector;
        playerVector = new Vector3(playerVector.x, 0, playerVector.y);
        if (_movable.IsMoved)
        {
            transform.position += playerVector * Time.deltaTime * _speed;
            _animator.SetBool("IsRunning", true);
            if (playerVector != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(playerVector, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            _animator.SetBool("IsRunning", false);
        }
    }
}

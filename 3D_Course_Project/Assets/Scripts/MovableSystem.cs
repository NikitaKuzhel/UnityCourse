using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableSystem : MonoBehaviour
{
    [SerializeField] private JoystickDetector _movable;
    [SerializeField] private float _speed = 12f;
    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] private Animator _animator;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // построение вектора персонажа на основе вектора джойстика
        Vector3 playerVector = _movable.MotionVector;
        playerVector = new Vector3(playerVector.x, 0, playerVector.y);

        // движение персонажа
        if (_movable.IsMoved)
        {
            transform.position += playerVector * Time.deltaTime * _speed;
            _animator.SetBool("IsRunning", true);

            // разворот персонажа
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

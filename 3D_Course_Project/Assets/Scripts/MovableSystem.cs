using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableSystem : MonoBehaviour
{
    [SerializeField] private JoystickDetector _movable;
    [SerializeField] private float _speed = 12f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_movable.IsMoved)
        {
            transform.position += _movable.MotionVector * Time.deltaTime * _speed;
        }
    }
}

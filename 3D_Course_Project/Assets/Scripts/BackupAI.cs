﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BackupAI : MonoBehaviour
{
    private const float MaxDistance = 2f;

    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _player;
    [SerializeField] Animator _animator;
    [SerializeField] private ShootingBehaviour _shoot;

    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private LayerMask _whatIsPlayer;

    // Патрулирование
    [SerializeField] private Vector3 _walkPoint;
    [SerializeField] private float _walkPointRange;
    private bool _walkPointSet;

    // Атака
    [SerializeField] private float _timeBetweenAttacks;
    private bool _alreadyAttacked;

    // Состояния
    [SerializeField] private float _sightRange;
    [SerializeField] private float _attackRange;
    [SerializeField] private bool _playerInSightRange;
    [SerializeField] private bool _playerInAttackRange;
    private State _state;

    public enum State
    {
        Patroling,
        ChasePlayer,
        AttackPlayer
    }

    private void Awake()
    {
        _player = GameObject.Find("Player").transform;
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        switch (_state)
        {
            case State.Patroling:
                Patroling();
                break;
            case State.ChasePlayer:
                ChasePlayer();
                break;
            case State.AttackPlayer:
                AttackPlayer();
                break;
        }
    }

    private void FixedUpdate()
    {

    }

    private void Patroling()
    {
        if (!_walkPointSet)
        {
            SearchWalkPoint();
        }

        if (_walkPointSet)
        {
            _agent.SetDestination(_walkPoint);
            _animator.SetBool("IsRunning", true);
        }

        Vector3 distanceToWalkPoint = transform.position - _walkPoint;

        // Если точка назначения достигнута
        if (distanceToWalkPoint.magnitude < 1)
        {
            _walkPointSet = false;
        }

        _playerInSightRange = Physics.CheckSphere(transform.position, _sightRange, _whatIsPlayer);
        if (_playerInSightRange) _state = State.ChasePlayer;
    }

    private void SearchWalkPoint()
    {
        // Вычисляет ранодомную точку в радиусе
        float randomZ = Random.Range(-_walkPointRange, _walkPointRange);
        float randomX = Random.Range(-_walkPointRange, _walkPointRange);

        _walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(_walkPoint, -transform.up, MaxDistance, _whatIsGround))
        {
            _walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        _agent.SetDestination(_player.position);

        _animator.SetBool("IsRunning", true);

        _playerInSightRange = Physics.CheckSphere(transform.position, _sightRange, _whatIsPlayer);
        _playerInAttackRange = Physics.CheckSphere(transform.position, _attackRange, _whatIsPlayer);
        if (!_playerInSightRange) _state = State.Patroling;
        if (_playerInSightRange && _playerInAttackRange) _state = State.AttackPlayer;
    }

    private void AttackPlayer()
    {
        // Остановить бота
        _agent.SetDestination(transform.position);

        transform.LookAt(_player);

        _animator.SetBool("IsRunning", false);

        if (!_alreadyAttacked)
        {
            _shoot.Shoot();
            //Debug.Log("SHOOT");

            _alreadyAttacked = true;
            Invoke(nameof(ResetAttack), _timeBetweenAttacks);
        }

        _playerInAttackRange = Physics.CheckSphere(transform.position, _attackRange, _whatIsPlayer);
        if (!_playerInAttackRange) _state = State.ChasePlayer;
    }

    private void ResetAttack()
    {
        _alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _sightRange);
    }
}
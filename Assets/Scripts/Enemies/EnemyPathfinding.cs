using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    private enum State 
    {
        Roaming = 0,
        Attack = 1
    }

    private float _moveSpeed;

    private Rigidbody2D _rigidBody;
    private Vector2 _moveDirection;
    private Vector2 _attackPosition;
    private SpriteRenderer _spriteRenderer;
    private EnemyAI _enemyAI;
    private EnemyStats _enemyStats;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _enemyAI = GetComponent<EnemyAI>();
        _enemyStats = GetComponent<EnemyStats>();
        _moveSpeed = _enemyStats.MoveSpeed;
    }

    private void FixedUpdate()
    {
        if (_enemyAI.GetState() == (int)State.Roaming)
        {
            _rigidBody.MovePosition(_rigidBody.position + _moveDirection * (_moveSpeed * Time.fixedDeltaTime));
        }
        else if (_enemyAI.GetState() == (int)State.Attack)
        {
            if (Vector2.Distance(_rigidBody.position, _attackPosition) >= _enemyStats.StopDistance)
            {
                transform.position = Vector2.MoveTowards(_rigidBody.position, _attackPosition, _moveSpeed * Time.fixedDeltaTime);
                transform.position = new Vector3(transform.position.x, transform.position.y, -0.2f);
            }
        }
    }

    public void MoveTo(Vector2 targetPosition)
    {
        if (targetPosition.x < 0)
            _spriteRenderer.flipX = true;
        else
            _spriteRenderer.flipX = false;

        _moveDirection = targetPosition;
    }

    public void MoveAndAttack(Vector2 targetPosition)
    {
        if (targetPosition.x < transform.position.x)
            _spriteRenderer.flipX = true;
        else
            _spriteRenderer.flipX = false;

        _attackPosition = targetPosition;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2.0f;

    private Rigidbody2D _rigidBody;
    private Vector2 _moveDirection;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        _rigidBody.MovePosition(_rigidBody.position + _moveDirection * (_moveSpeed * Time.fixedDeltaTime));
    }

    public void MoveTo(Vector2 targetPosition)
    {
        if (targetPosition.x < 0)
            _spriteRenderer.flipX = true;
        else
            _spriteRenderer.flipX = false;

        _moveDirection = targetPosition;
    }
}

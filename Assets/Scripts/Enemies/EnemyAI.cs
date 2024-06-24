using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State 
    {
        Roaming = 0,
        Attack = 1
    }

    private State _state;
    private float _waitTime = 2.0f;
    private float _attackSpeed;
    private EnemyPathfinding _enemyPathfinding;
    private GameObject _player;
    private EnemyStats _enemyStats;
    private Animator _enemyAnimator;
    private bool _isAttack = false;

    private void Awake()
    {
        _enemyStats = GetComponent<EnemyStats>();
        _enemyAnimator = GetComponent<Animator>();
        _enemyPathfinding = GetComponent<EnemyPathfinding>();
        _state = State.Roaming;
        _attackSpeed = _enemyStats.AttackSpeed;
    }

    private void Start() 
    {
        StartCoroutine(RoamingRouting());
    }

    private IEnumerator RoamingRouting()
    {
        while (_state == State.Roaming)
        {
            Vector2 roamPosition = GetRoamingPosition();
            
            _enemyPathfinding.MoveTo(roamPosition);
            yield return new WaitForSeconds(_waitTime);
        }
    }

    private IEnumerator AttackMovementRouting()
    {
        while (_state == State.Attack)
        {
            _enemyPathfinding.MoveAndAttack(_player.transform.position);
            yield return new WaitForSeconds(_waitTime);
        }
    }

    private IEnumerator AttackRouting()
    {
        while (_isAttack == true)
        {
            _enemyAnimator.SetBool("Attack", true);
            _player.GetComponent<PlayerStats>().RemoveHealth(_enemyStats.Damage);
            yield return new WaitForSeconds(_attackSpeed);
            _enemyAnimator.SetBool("Attack", false);
        }
    }

    private Vector2 GetRoamingPosition()
    {
        return new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
    }

    public int GetState()
    {
        return (int)_state;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            _player = collider.transform.gameObject;
            _state = State.Attack;
            StopCoroutine(RoamingRouting());
            StartCoroutine(AttackMovementRouting());
        }    
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            _state = State.Roaming;
            StopCoroutine(AttackMovementRouting());
            StartCoroutine(RoamingRouting());
        }
    }

    public void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            _isAttack = true;
            StartCoroutine(AttackRouting());
            StopCoroutine(AttackMovementRouting());
        }
    }

    public void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            _isAttack = false;
            _enemyAnimator.SetBool("Attack", false);
            StopCoroutine(AttackRouting());
            StartCoroutine(AttackMovementRouting());
        }
    }
}

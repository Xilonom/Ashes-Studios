using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State 
    {
        Roaming
    }

    private State _state;
    private float _waitTime = 2.0f;
    private EnemyPathfinding _enemyPathfinding;

    private void Awake()
    {
        _enemyPathfinding = GetComponent<EnemyPathfinding>();
        _state = State.Roaming;
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

    private Vector2 GetRoamingPosition()
    {
        return new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
    }
}

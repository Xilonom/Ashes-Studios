using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("Main Enemy Stats")]
    [SerializeField] private float _health = 100.0f;
    [SerializeField] private float _damage = 5.0f;
    [SerializeField] private float _moveSpeed = 2.0f;
    [SerializeField] private float _attackSpeed = 1.0f;
    [Space(10)]

    [SerializeField] private float _stopDistance = 1.0f;

    public float MoveSpeed
    {
        get { return _moveSpeed; }
        set { _moveSpeed = value; }
    }

    public float Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    public float AttackSpeed
    {
        get { return _attackSpeed; }
        set { _attackSpeed = value; }
    }

    public float StopDistance
    {
        get { return _stopDistance; }
        set { _stopDistance = value; }
    }

}

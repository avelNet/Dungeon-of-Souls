using Assets.Scripts.Enemy;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Текущее состояние")]
    private State _currentState;

    [Header("Компоненты для врага")]
    private Animator _animator;
    private Rigidbody2D _rb;
    private Transform _player;
    private EnemyVisual _visual;

    [Header("Патрулирование")]
    private Vector2 _patrolTarget;
    private Vector2 _lastPosition;
    private float _patrolRange = 5f;
    private float _patrolStopDistance = 0.2f;
    private float _stuckTimer;
    private float _stuckTime = 0.5f;
    private float _runningRange = 3f;
    private float _enemySpeed = 2f;
    private float _chasingEnemySpeed = 5f;

    [Header("Преследование")]
    private float _chasingRange = 3f;

    [Header("Атака")]
    private float _attackingRange = 1f;

    private float _obstacleCheckDistance = 2f;
    [SerializeField] private LayerMask _obstacleMask;
    public enum State
    {
        Idle,
        Patrol,
        Chasing,
        Attacking
    }

    private void Awake()
    {
        _visual = GetComponentInChildren<EnemyVisual>();
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _animator = GetComponent<Animator>();
        _currentState = State.Idle;
    }

    private void FixedUpdate()
    {
        SwitchState();
    }

    private void SwitchState()
    {
        switch(_currentState)
        {
            case State.Idle:
                Idle();
                break;
            case State.Patrol:
                Patrol();
                break;
            case State.Chasing:
                Chasing();
                break;
            /*case State.Attacking:
                Attacking();
                break;*/
        }
    }

    private void Idle()
    {
        _animator.SetBool("isRunning", false);
        _rb.linearVelocity = Vector3.zero;

        float distance = Vector2.Distance(transform.position, _player.position);

        if(distance >= _patrolRange)
        {
            _patrolTarget = GetRandomDirectionPoint();
            _currentState = State.Patrol;
        }
    }

    private void CheckIfStuck() // метод при застревание не в коллайдере
    {
        if (Vector2.Distance(_rb.position, _lastPosition) < 0.01f)
        {
            _stuckTimer += Time.deltaTime;
            if (_stuckTimer >= _stuckTime)
            {
                _patrolTarget = GetRandomDirectionPoint();
                _stuckTimer = 0f;
            }
        }
        else
        {
            _stuckTimer = 0f;
            _lastPosition = _rb.position;
        }
    }

    private Vector2 GetRandomDirectionPoint()
    {
        Vector2 randomPoint = (Vector2)transform.position + Random.insideUnitCircle * _runningRange;
        return randomPoint;
    }

    private bool IsObstacleHead(Vector2 dir) // метод при застревание в коллайдере
    {
        RaycastHit2D hit = Physics2D.Raycast(
            _rb.position,
            dir,
            _obstacleCheckDistance,
            _obstacleMask);

        return hit.collider != null;
    }

    private void Patrol()
    {
        _animator.SetBool("isRunning", true);

        Vector2 dir = (_patrolTarget - _rb.position).normalized;

        if(IsObstacleHead(dir))
        {
            _patrolTarget = GetRandomDirectionPoint();
            return;
        }

        _visual.FlipXEnemy(dir);
        _rb.MovePosition(_rb.position + dir * (_enemySpeed * Time.deltaTime));
        CheckIfStuck();

        if(Vector2.Distance(_rb.position, _patrolTarget) <= _patrolStopDistance)
        {
            _patrolTarget = GetRandomDirectionPoint();
        }

        float dist = Vector2.Distance(_player.position, transform.position);
        if(dist >= 3 && dist < 5)
        {
            _currentState = State.Chasing;
        }
    }

    private void Chasing()
    {
        _animator.SetBool("isChasing", true);
        _animator.SetBool("isRunning", false);
        Vector2 dir = (Vector2)_player.position - _rb.position;
        _rb.linearVelocity = dir.normalized * _chasingEnemySpeed;
    }
}

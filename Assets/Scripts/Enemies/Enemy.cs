using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    private NavMeshAgent _enemyNavMeshAgent;

    [SerializeField]
    private LayerMask _playerLayerMask;
    [SerializeField]
    private LayerMask _arenaLayerMask;

    [SerializeField]
    protected GameObject _playerGameObject;

    [SerializeField]
    private float _sightRange = 10f;
    [SerializeField]
    private float _attackRange = 1f;
    [SerializeField]
    private float _moveSpeed = 1f;
    protected bool _isPlayerInSightRange;
    protected bool _isPlayerInAttackRange;

    private Vector3 _patrolPoint;
    private bool _isPatrolPoinSet = false;
    [SerializeField]
    private float _patrolRange = 8f;

    [SerializeField]
    private float _attackSpeed;
    private float _timeToNextAttack = 0f;
    [SerializeField]
    protected float _damage = 10f;

    public float health;

    private Animator _enemyAnimator;
    private int _isMovingHash = Animator.StringToHash("isMoving");
    private int _attackHash = Animator.StringToHash("Attack");
    private int _deathHash = Animator.StringToHash("Death");

    void Start()
    {
        _enemyNavMeshAgent = GetComponent<NavMeshAgent>();
        _enemyAnimator = GetComponent<Animator>();

        _enemyNavMeshAgent.speed = _moveSpeed;
    }

    void Update()
    {
        CheckIfPlayerInRange();
        ResetAttackTimer();
        CheckIfAlive();
    }

    private void CheckIfAlive()
    {
        if (health <= 0)
        {
            _enemyAnimator.SetTrigger(_deathHash);
        }
    }

    private void Kill()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _sightRange);
    }

    private void CheckIfPlayerInRange()
    {
        _isPlayerInSightRange = Physics.CheckSphere(transform.position, _sightRange, _playerLayerMask);
        _isPlayerInAttackRange = Physics.CheckSphere(transform.position, _attackRange, _playerLayerMask);

        if (!_isPlayerInSightRange && !_isPlayerInAttackRange) 
        {
            Patroling();
        }
        if(_isPlayerInSightRange && !_isPlayerInAttackRange)
        {
            ChasePlayer();
        }
        if(_isPlayerInSightRange && _isPlayerInAttackRange)
        {
            AttackPlayer();
        }
    }

    private void Patroling()
    {
        if (!_isPatrolPoinSet)
        {
            SearchPatrolPoint();
        }
        else
        {
            _enemyNavMeshAgent.SetDestination(_patrolPoint);

            Vector3 distanceToPatrolPoint = transform.position - _patrolPoint;
            _enemyAnimator.SetBool(_isMovingHash, true);

            if(distanceToPatrolPoint.magnitude < 1f)
            {
                _isPatrolPoinSet = false;
                _enemyAnimator.SetBool(_isMovingHash, false);
            }
        }
    }

    private void SearchPatrolPoint()
    {
        float randomX = Random.Range(-_patrolRange, _patrolRange);
        float randomZ = Random.Range(-_patrolRange, _patrolRange);

        _patrolPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(_patrolPoint, -transform.up, 2f, _arenaLayerMask))
        {
            _isPatrolPoinSet = true;
        }
    }

    private void ChasePlayer()
    {
        _enemyNavMeshAgent.SetDestination(_playerGameObject.transform.position);
        _enemyAnimator.SetBool(_isMovingHash, true);
    }

    private void AttackPlayer()
    {
        _enemyAnimator.SetBool(_isMovingHash, false);
        _enemyNavMeshAgent.SetDestination(transform.position);

        Vector3 lookTarget = new Vector3(_playerGameObject.transform.position.x, transform.position.y, _playerGameObject.transform.position.z);
        transform.LookAt(lookTarget);

        if(_timeToNextAttack <= 0f)
        {
            _enemyAnimator.SetTrigger(_attackHash);

            _timeToNextAttack += Time.deltaTime;
        }
    }

    private void ResetAttackTimer()
    {
        if (_timeToNextAttack > 0f && _timeToNextAttack < _attackSpeed)
        {
            _timeToNextAttack += Time.deltaTime;
        }
        if (_timeToNextAttack >= _attackSpeed)
        {
            _timeToNextAttack = 0;
        }
    }

    protected abstract void Attack();

}

using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MovementController
{

	[SerializeField] float _moveDist = 10f;
	[SerializeField] float _visionLength = 5f;
	[SerializeField] float _peripherialAngle = 30f;
	[SerializeField] TransformScrObj _playerObj;
	[SerializeField] Selector _wallSelector;
	[SerializeField] ShootMono _shoot;
	[SerializeField] NavMeshAgent _navMeshAgent;
	[SerializeField] Transform _enemyTransform;

	StateMachine _enemyTargetStateMachine;
	Transform _player;

	int _calculatedPlayerInSight = 0;
	bool _playerInSight = false;
	public MoveBackAndForthState moveBackAndForthState;

	void OnEnable()
	{
		MaxSpeed = _navMeshAgent.speed;

		_player = _playerObj.GetTransform();

		float stoppingDistance = _navMeshAgent.stoppingDistance;

		moveBackAndForthState = new MoveBackAndForthState(_enemyTransform, _moveDist, _navMeshAgent, stoppingDistance);
		var targetPlayer = new TargetAndShootEntity(_player, _navMeshAgent, _enemyTransform, _shoot);

		_enemyTargetStateMachine = new StateMachine();

		_enemyTargetStateMachine.AddAnyTransition(moveBackAndForthState, NotPlayerInSight);
		_enemyTargetStateMachine.AddAnyTransition(targetPlayer, PlayerInSight);
	}

	bool PlayerInSight()
	{
		if (_calculatedPlayerInSight == 1) return _playerInSight;

		Vector3 diff = _player.position - _enemyTransform.position;
		Debug.DrawLine(_enemyTransform.position, _enemyTransform.position + diff.normalized * _visionLength, Color.red);
		if (diff.magnitude > _visionLength)
		{
			_playerInSight = false;
			return false;
		}

		Ray ray = new Ray(_enemyTransform.position, diff.normalized);
		_wallSelector.CheckRay(ray);
		if (_wallSelector.GetSelection() != null)
		{
			_playerInSight = false;
			return false;
		}

		if (Vector3.Dot(diff.normalized, _enemyTransform.forward) < Mathf.Cos(_peripherialAngle * Mathf.Deg2Rad))
		{
			_playerInSight = false;
			return false;
		}

		_playerInSight = true;
		_calculatedPlayerInSight = 1;
		return true;
	}

	bool NotPlayerInSight()
	{
		if (_calculatedPlayerInSight == 0)
		{
			PlayerInSight();
		}
		return !_playerInSight;
	}

	void Update()
	{
		Move();
		// Debug.Log(_navMeshAgent.destination);
	}

	public override void Move()
	{
		_calculatedPlayerInSight = 0;

		speed = _navMeshAgent.velocity.magnitude;
		_enemyTargetStateMachine.Tick();
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		if (moveBackAndForthState != null)
		{
			Gizmos.DrawSphere(moveBackAndForthState._forwardPos, 0.2f);
			Gizmos.DrawSphere(moveBackAndForthState._backPos, 0.2f);
		}
	}
}



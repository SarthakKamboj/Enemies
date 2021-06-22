using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAllyEnemyController : NpcController
{

	[SerializeField] NavMeshAgent _navMeshAgent;
	[SerializeField] Transform _enemyTransform;
	[SerializeField] ShootMono _shoot;
	[SerializeField] TransformScrObj _playerObj;
	[SerializeField] float _enemyDetectionRadius = 10f, _vicinityDistance = 7.5f;
	[SerializeField] LayerMask _enemyLayerMask;

	Transform _player;

	StateMachine _actionStateMachine;
	TargetAndShootEntity _targetEnemy;

	void Start()
	{
		_player = _playerObj.GetTransform();

		float stoppingDistance = _navMeshAgent.stoppingDistance;

		_targetEnemy = new TargetAndShootEntity(_navMeshAgent, _enemyTransform, _shoot);
		var followPlayer = new FollowEntity(_player, _navMeshAgent, _enemyTransform, _vicinityDistance);

		_actionStateMachine = new StateMachine();
		_actionStateMachine.AddAnyTransition(_targetEnemy, IsEnemyDetected);
		_actionStateMachine.AddAnyTransition(followPlayer, NotEnemyDetected);

	}

	bool NotEnemyDetected()
	{
		return !IsEnemyDetected();
	}

	bool IsEnemyDetected()
	{
		Collider[] colliders = Physics.OverlapSphere(_enemyTransform.position, _enemyDetectionRadius, _enemyLayerMask);
		bool detected = colliders.Length >= 1;
		if (detected)
		{
			_targetEnemy.SetTargetEntity(colliders[0].transform);
		}
		return detected;
	}

	void OnEnable()
	{
		MaxSpeed = _navMeshAgent.speed;
	}

	public override void Move()
	{
		_actionStateMachine.Tick();
	}

	void Update()
	{
		speed = _navMeshAgent.velocity.magnitude;
		Move();
	}
}

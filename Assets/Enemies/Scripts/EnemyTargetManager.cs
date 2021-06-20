using UnityEngine;
using UnityEngine.AI;

public class EnemyTargetManager : MonoBehaviour
{

	[SerializeField] float _moveDist = 10f;
	[SerializeField] float _visionLength = 5f;
	[SerializeField] float _peripherialAngle = 30f;
	[SerializeField] TransformScrObj _playerObj;
	[SerializeField] Selector _wallSelector;

	StateMachine _enemyTargetStateMachine;
	Transform _player;
	Transform _t;

	int _calculatedPlayerInSight = 0;
	bool _playerInSight = false;

	void Awake()
	{
		_t = transform;
		_playerObj.AddTransformChangeListener(UpdatePlayerRef);
	}

	void Start()
	{
		UpdatePlayerRef(_playerObj.GetTransform());

		ShootMono shoot = GetComponent<ShootMono>();
		NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
		float stoppingDistance = navMeshAgent.stoppingDistance;

		var moveBackAndForthState = new MoveBackAndForthState(transform, _moveDist, navMeshAgent, stoppingDistance);
		var targetPlayer = new TargetPlayer(_player, navMeshAgent, _t, shoot);

		_enemyTargetStateMachine = new StateMachine();

		_enemyTargetStateMachine.AddAnyTransition(moveBackAndForthState, NotPlayerInSight);
		_enemyTargetStateMachine.AddAnyTransition(targetPlayer, PlayerInSight);
	}

	bool PlayerInSight()
	{
		if (_calculatedPlayerInSight == 1) return _playerInSight;

		Vector3 diff = _player.position - _t.position;
		Debug.DrawLine(_t.position, _t.position + diff.normalized * _visionLength, Color.red);
		if (diff.magnitude > _visionLength)
		{
			_playerInSight = false;
			return false;
		}

		Ray ray = new Ray(_t.position, diff.normalized);
		_wallSelector.CheckRay(ray);
		if (_wallSelector.GetSelection() != null)
		{
			_playerInSight = false;
			return false;
		}

		if (Vector3.Dot(diff.normalized, _t.forward) < Mathf.Cos(_peripherialAngle * Mathf.Deg2Rad))
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

	void UpdatePlayerRef(Transform t)
	{
		_player = t;
	}

	void Update()
	{
		_calculatedPlayerInSight = 0;
		_enemyTargetStateMachine.Tick();
	}
}



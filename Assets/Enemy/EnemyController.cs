using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

	[SerializeField] NavMeshAgent _agent;
	[SerializeField] TransformScrObj _playerObj;
	[SerializeField] Animator _enemyAnimator;
	[SerializeField] float TimeBetweenEnemyMove = 5f;

	Transform _t;
	EnemyDie _baseEnemyDie;
	Transform _player;
	int speedHash;
	Vector3 _targetPos;
	float _timeUntilEnemyMove;
	RandomPosition _nearPlayerRandomPositionProvider;


	void Awake()
	{
		_t = transform;
		_baseEnemyDie = GetComponent<EnemyDie>();
		_baseEnemyDie.AddEnemyDieListener(OnEnemyDie);

		_playerObj.AddTransformChangeListener(UpdatePlayerRef);
		speedHash = Animator.StringToHash("Speed");

		_timeUntilEnemyMove = TimeBetweenEnemyMove;
	}

	void Start()
	{
		UpdatePlayerRef(_playerObj.GetTransform());
		_nearPlayerRandomPositionProvider = _player.GetComponent<RandomPosition>();
		GetNewTargetPosition();
	}

	void OnDestroy()
	{
		_baseEnemyDie.RemoveEnemyDieListener(OnEnemyDie);
		_playerObj.RemoveTransformChangeListener(UpdatePlayerRef);
	}

	void UpdatePlayerRef(Transform t)
	{
		_player = t;
	}

	void Update()
	{

		_timeUntilEnemyMove = Mathf.Max(_timeUntilEnemyMove - Time.deltaTime, 0f);

		if (_timeUntilEnemyMove <= 0f)
		{
			_timeUntilEnemyMove = TimeBetweenEnemyMove;
			GetNewTargetPosition();
		}

		Vector3 lookDir = (_player.position - _t.position).normalized;
		_t.rotation = Quaternion.LookRotation(lookDir, Vector3.up);
		_agent.SetDestination(_targetPos);
		float normalizedAgentVel = _agent.velocity.magnitude / _agent.speed;
		_enemyAnimator.SetFloat(speedHash, normalizedAgentVel);
	}

	void GetNewTargetPosition()
	{
		_targetPos = _nearPlayerRandomPositionProvider.GetRandomPosition();
	}

	void OnEnemyDie()
	{
		_agent.enabled = false;
		this.enabled = false;
	}

}

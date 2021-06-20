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

		float normalizedAgentVel = _agent.velocity.magnitude / _agent.speed;
		_enemyAnimator.SetFloat(speedHash, normalizedAgentVel);
	}

	void OnEnemyDie()
	{
		_agent.enabled = false;
		this.enabled = false;
	}

}

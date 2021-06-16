using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

	[SerializeField] NavMeshAgent _agent;
	[SerializeField] TransformScrObj _playerObj;
	[SerializeField] Animator _enemyAnimator;

	Transform _t;
	EnemyDie _baseEnemyDie;
	Transform _player;
	int speedHash;


	void Awake()
	{
		_t = transform;
		_baseEnemyDie = GetComponent<EnemyDie>();
		_baseEnemyDie.AddEnemyDieListener(OnEnemyDie);

		_playerObj.AddTransformChangeListener(UpdatePlayerRef);
		speedHash = Animator.StringToHash("Speed");
	}

	void Start()
	{
		UpdatePlayerRef(_playerObj.GetTransform());
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
		Vector3 lookDir = (_player.position - _t.position).normalized;
		_t.rotation = Quaternion.LookRotation(lookDir, Vector3.up);
		_agent.SetDestination(_player.position);
		float normalizedAgentVel = _agent.velocity.magnitude / _agent.speed;
		_enemyAnimator.SetFloat(speedHash, normalizedAgentVel);
	}

	void OnEnemyDie()
	{
		_agent.enabled = false;
		this.enabled = false;
	}
}

using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

	[SerializeField] NavMeshAgent _agent;
	[SerializeField] Transform _player;

	Transform _t;
	EnemyDie _baseEnemyDie;


	void Awake()
	{
		_t = transform;
		_baseEnemyDie = GetComponent<EnemyDie>();
		_baseEnemyDie.AddEnemyDieListener(OnEnemyDie);
	}

	void OnDestroy()
	{
		_baseEnemyDie.RemoveEnemyDieListener(OnEnemyDie);
	}

	void Update()
	{
		Vector3 lookDir = (_player.position - _t.position).normalized;
		_t.rotation = Quaternion.LookRotation(lookDir, Vector3.up);
		_agent.SetDestination(_player.position);
	}

	void OnEnemyDie()
	{
		_agent.enabled = false;
		this.enabled = false;
	}
}

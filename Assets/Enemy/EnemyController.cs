using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

	[SerializeField] NavMeshAgent _agent;
	[SerializeField] Transform _player;

	Transform _t;

	void Start()
	{
		_t = transform;
	}

	void Update()
	{
		Vector3 lookDir = (_player.position - _t.position).normalized;
		_t.rotation = Quaternion.LookRotation(lookDir, Vector3.up);
		_agent.SetDestination(_player.position);
	}
}

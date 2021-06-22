using UnityEngine;
using UnityEngine.AI;

public class FollowEntity : State
{
	Transform _target, _t;
	NavMeshAgent _agent;

	public FollowEntity(Transform target, NavMeshAgent agent, Transform t)
	{
		_target = target;
		_agent = agent;
		_t = t;
	}

	public override void Tick()
	{
		Vector3 lookDir = (_target.position - _t.position).normalized;
		// _t.rotation = Quaternion.LookRotation(lookDir, Vector3.up);
		_t.rotation = _target.rotation;
		_agent.SetDestination(_target.position);
	}
}

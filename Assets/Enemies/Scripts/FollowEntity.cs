using UnityEngine;
using UnityEngine.AI;

public class FollowEntity : State
{
	Transform _target, _t;
	NavMeshAgent _agent;
	float _vicinityDistance;
	float _curVel;

	public FollowEntity(Transform target, NavMeshAgent agent, Transform t, float vicinityDistance)
	{
		_target = target;
		_agent = agent;
		_t = t;
		_vicinityDistance = vicinityDistance;
	}

	public override void Tick()
	{
		Vector3 diff = _target.position - _t.position;
		Quaternion targetQuat;
		if (diff.magnitude > _vicinityDistance)
		{
			Vector3 lookDir = diff.normalized;
			targetQuat = Quaternion.LookRotation(lookDir, Vector3.up);
		}
		else
		{
			targetQuat = _target.rotation;
		}

		float targetYRot = targetQuat.eulerAngles.y;
		float yRot = Mathf.SmoothDampAngle(_t.eulerAngles.y, targetYRot, ref _curVel, 0.2f);
		_t.rotation = Quaternion.Euler(new Vector3(0f, yRot, 0f));

		_agent.SetDestination(_target.position);
	}
}

using UnityEngine;
using UnityEngine.AI;

public class TargetAndShootEntity : State
{

	Transform _target, _t;
	NavMeshAgent _agent;
	ShootMono _shoot;

	public TargetAndShootEntity(Transform target, NavMeshAgent agent, Transform t, ShootMono shoot)
	{
		_target = target;
		_agent = agent;
		_t = t;
		_shoot = shoot;
	}

	public TargetAndShootEntity(NavMeshAgent agent, Transform t, ShootMono shoot)
	{
		_agent = agent;
		_t = t;
		_shoot = shoot;
	}

	public void SetTargetEntity(Transform newEntity)
	{
		_target = newEntity;
	}

	public override void Tick()
	{
		Vector3 lookDir = (_target.position - _t.position).normalized;
		Quaternion quat = Quaternion.LookRotation(lookDir, Vector3.up);
		Quaternion straightQuat = Quaternion.Euler(new Vector3(0f, quat.eulerAngles.y, 0f));
		_t.rotation = straightQuat;
		_shoot.Shoot();
		_agent.SetDestination(_target.position);
	}

}



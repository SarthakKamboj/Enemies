using UnityEngine;
using UnityEngine.AI;

public partial class EnemyTarget
{
	class TargetPlayer : State
	{

		Transform _player, _t;
		NavMeshAgent _agent;
		ShootBase _shoot;

		public TargetPlayer(Transform player, NavMeshAgent agent, Transform t, ShootBase shoot)
		{
			_player = player;
			_agent = agent;
			_t = t;
			_shoot = shoot;
		}

		public override void Tick()
		{
			Vector3 lookDir = (_player.position - _t.position).normalized;
			_t.rotation = Quaternion.LookRotation(lookDir, Vector3.up);
			_shoot.Shoot();
			_agent.SetDestination(_player.position);
		}
	}
}



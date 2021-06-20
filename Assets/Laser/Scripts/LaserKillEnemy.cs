using System;
using UnityEngine;

public class LaserKillEnemy : MonoBehaviour
{

	[SerializeField] LayerMask _enemyLayerMask;
	Action OnEnemyKilled;
	LaserActivationManager _laserActivationManager;

	void Awake()
	{
		_laserActivationManager = GetComponent<LaserActivationManager>();
	}

	public void AddOnEnemyKilledListener(Action func)
	{
		OnEnemyKilled += func;
	}

	public void RemoveOnEnemyKilledListener(Action func)
	{
		OnEnemyKilled -= func;
	}

	void OnTriggerEnter(Collider collider)
	{
		if (IsEnemy(collider.transform) && !_laserActivationManager.IsLaserDeactivated())
		{
			EnemyDie enemyDie = collider.GetComponent<EnemyDie>();
			enemyDie.Die();
			OnEnemyKilled?.Invoke();
		}
	}

	bool IsEnemy(Transform enemy)
	{
		return _enemyLayerMask == (_enemyLayerMask | (1 << enemy.gameObject.layer));
	}

}

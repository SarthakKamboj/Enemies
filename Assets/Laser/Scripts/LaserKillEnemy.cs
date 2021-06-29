using System;
using UnityEngine;

public class LaserKillEnemy : MonoBehaviour
{

	[SerializeField] LayerMask _enemyLayerMask;
	Action OnEnemyKilled;
	LaserActivationManager _laserActivationManager;
	bool runtime = false;

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

	void Start()
	{
		runtime = true;
	}

	void OnTriggerEnter(Collider collider)
	{
		if (runtime && IsEnemy(collider.transform) && !_laserActivationManager.IsLaserDeactivated())
		{
			DieMono enemyDie = collider.GetComponent<DieMono>();
			enemyDie.Die();
			OnEnemyKilled?.Invoke();
		}
	}

	bool IsEnemy(Transform enemy)
	{
		return _enemyLayerMask == (_enemyLayerMask | (1 << enemy.gameObject.layer));
	}

}

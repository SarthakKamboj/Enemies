using System;
using UnityEngine;

public class DisposeEnemy : MonoBehaviour
{

	[SerializeField] Selector _deadEnemyDropOffSelector;

	RayProvider _cameraRayProvider;
	EnemyStorage _enemyStorage;
	Action OnEnemyDropOff;


	void Awake()
	{
		_cameraRayProvider = GetComponent<RayProvider>();
		_enemyStorage = GetComponent<EnemyStorage>();
	}

	public void AddEnemyDropOffListener(Action func)
	{
		OnEnemyDropOff += func;
	}

	public void RemoveEnemyDropOffListener(Action func)
	{
		OnEnemyDropOff -= func;
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = _cameraRayProvider.GetRay();
			_deadEnemyDropOffSelector.CheckRay(ray);
			Transform storedEnemy = _enemyStorage.GetEnemy();
			if (_deadEnemyDropOffSelector.GetSelection() != null && storedEnemy != null)
			{
				_enemyStorage.DropEnemy();
				OnEnemyDropOff?.Invoke();
				Destroy(storedEnemy.gameObject);
			}
		}
	}
}

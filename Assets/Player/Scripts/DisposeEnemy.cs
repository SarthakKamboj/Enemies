using System;
using System.Collections.Generic;
using UnityEngine;

public class DisposeEnemy : MonoBehaviour
{

	[SerializeField] Selector _deadEnemyDropOffSelector;

	RayProvider _cameraRayProvider;
	Storage _enemyParticleStorage;

	public delegate void EnemyDropOff(int numEnemies);
	EnemyDropOff OnEnemyDropOff;


	void Awake()
	{
		_cameraRayProvider = GetComponent<RayProvider>();
		_enemyParticleStorage = GetComponent<Storage>();
	}

	public void AddEnemyDropOffListener(EnemyDropOff func)
	{
		OnEnemyDropOff += func;
	}

	public void RemoveEnemyDropOffListener(EnemyDropOff func)
	{
		OnEnemyDropOff -= func;
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = _cameraRayProvider.GetRay();
			_deadEnemyDropOffSelector.CheckRay(ray);
			List<Transform> storedEnemyParticleList = _enemyParticleStorage.GetItemsFromStorage();
			Transform selection = _deadEnemyDropOffSelector.GetSelection();

			if (selection != null && storedEnemyParticleList.Count != 0)
			{
				OnEnemyDropOff?.Invoke(storedEnemyParticleList.Count);
				_enemyParticleStorage.Clear();
			}
		}
	}
}

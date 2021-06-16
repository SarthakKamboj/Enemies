using System;
using System.Collections.Generic;
using UnityEngine;

public class DisposeEnemy : MonoBehaviour
{

	[SerializeField] Selector _deadEnemyDropOffSelector;

	RayProvider _cameraRayProvider;
	Storage _enemyParticleStorage;
	Action OnEnemyDropOff;


	void Awake()
	{
		_cameraRayProvider = GetComponent<RayProvider>();
		_enemyParticleStorage = GetComponent<Storage>();
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
			List<Transform> storedEnemyParticleList = _enemyParticleStorage.GetItemsFromStorage();
			Transform selection = _deadEnemyDropOffSelector.GetSelection();

			if (selection != null && storedEnemyParticleList.Count != 0)
			{
				_enemyParticleStorage.Clear();
				Debug.Log(_enemyParticleStorage.GetItemsFromStorage().Count);
				OnEnemyDropOff?.Invoke();
			}
		}
	}
}

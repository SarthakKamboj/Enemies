using System;
using System.Collections.Generic;
using UnityEngine;

public class DisposeEnemy : MonoBehaviour
{

	[SerializeField] float _maxRadiusToDropOff = 3f;
	[SerializeField] LayerMask _disposalLayerMask;

	Storage _enemyParticleStorage;
	Transform _t;

	public delegate void EnemyDropOff(int numEnemies);
	EnemyDropOff OnEnemyDropOff;


	void Awake()
	{
		_enemyParticleStorage = GetComponent<Storage>();
		_t = transform;
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
		List<Transform> storedEnemyParticleList = _enemyParticleStorage.GetItemsFromStorage();
		Collider[] colliders = Physics.OverlapSphere(_t.position, _maxRadiusToDropOff, _disposalLayerMask);
		if (colliders.Length == 0) return;

		Transform selection = colliders[0].transform;

		if (selection != null && storedEnemyParticleList.Count != 0)
		{
			OnEnemyDropOff?.Invoke(storedEnemyParticleList.Count);
			_enemyParticleStorage.Clear();
		}
	}
}

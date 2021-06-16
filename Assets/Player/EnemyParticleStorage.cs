using System.Collections.Generic;
using UnityEngine;

public class EnemyParticleStorage : Storage
{

	[SerializeField] TransformListScrObj _enemyParticleListObj;

	void OnDestroy()
	{
		Clear();
	}

	public override void AddToStorage(Transform t)
	{
		_enemyParticleListObj.AddTransform(t);
	}

	public override void RemoveFromStorage(Transform t)
	{
		_enemyParticleListObj.RemoveTransform(t);
	}

	public override List<Transform> GetItemsFromStorage()
	{
		return _enemyParticleListObj.GetTransformList();
	}

	public override void Clear()
	{
		_enemyParticleListObj.RemoveAllTransform();
	}
}

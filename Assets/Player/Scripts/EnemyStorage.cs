using System.Collections.Generic;
using UnityEngine;

public class EnemyStorage : Storage
{

	[SerializeField] Collider _collider;

	Vector3 _playerExtents;
	List<Transform> _enemyTransformList = new List<Transform>();

	void Awake()
	{
		_playerExtents = _collider.bounds.extents;
	}

	public override void AddToStorage(Transform t)
	{
		if (_enemyTransformList.Count == 0)
		{
			_enemyTransformList.Add(t);
		}
	}

	void LateUpdate()
	{
		if (_enemyTransformList.Count != 0)
		{
			_enemyTransformList[0].position = transform.position + new Vector3(0f, _playerExtents.y + 2f, 0f);
		}
	}

	public override List<Transform> GetItemsFromStorage()
	{
		return _enemyTransformList;
	}

	public override void RemoveFromStorage(Transform t)
	{
		_enemyTransformList.Clear();
	}

	public override void Clear()
	{
		_enemyTransformList.Clear();
	}
}

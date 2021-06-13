using UnityEngine;

public class EnemyStorage : MonoBehaviour
{

	[SerializeField] Collider _collider;

	Vector3 _playerExtents;
	Transform _enemyTransform;

	void Awake()
	{
		_playerExtents = _collider.bounds.extents;
	}

	public void SetEnemy(Transform t)
	{
		_enemyTransform = t;
	}

	void LateUpdate()
	{
		if (_enemyTransform != null)
		{
			_enemyTransform.position = transform.position + new Vector3(0f, _playerExtents.y + 2f, 0f);
		}
	}

	public Transform GetEnemy()
	{
		return _enemyTransform;
	}
}

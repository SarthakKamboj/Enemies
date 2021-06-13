using UnityEngine;

public class PickUpEnemy : MonoBehaviour
{

	[SerializeField] Selector _deadEnemySelector;

	RayProvider _screenRayProvider;
	Transform _enemyTransform;
	Vector3 _playerExtents;

	void Awake()
	{
		Cursor.lockState = CursorLockMode.Locked;
		_screenRayProvider = GetComponent<RayProvider>();
		_playerExtents = GetComponent<Collider>().bounds.extents;
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = _screenRayProvider.GetRay();
			_deadEnemySelector.CheckRay(ray);

			Transform deadEnemy = _deadEnemySelector.GetSelection();
			if (deadEnemy != null && deadEnemy.GetComponent<EnemyDie>().IsDead())
			{
				PickUp(deadEnemy);
			}


		}
	}

	void LateUpdate()
	{
		if (_enemyTransform != null)
		{
			_enemyTransform.position = transform.position + new Vector3(0f, _playerExtents.y + 2f, 0f);
		}
	}

	void PickUp(Transform t)
	{
		if (_enemyTransform == null)
		{
			_enemyTransform = t;
		}
	}
}

using UnityEngine;

public class PickUpEnemy : MonoBehaviour
{

	[SerializeField] Selector _deadEnemyPickUpSelector;

	RayProvider _screenRayProvider;
	EnemyStorage _enemyStorage;

	void Awake()
	{
		_screenRayProvider = GetComponent<RayProvider>();
		_enemyStorage = GetComponent<EnemyStorage>();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = _screenRayProvider.GetRay();
			_deadEnemyPickUpSelector.CheckRay(ray);

			Transform deadEnemy = _deadEnemyPickUpSelector.GetSelection();
			if (deadEnemy != null && deadEnemy.GetComponent<EnemyDie>().IsDead())
			{
				PickUp(deadEnemy);
			}


		}
	}

	void PickUp(Transform t)
	{
		if (_enemyStorage.GetEnemy() == null)
		{
			_enemyStorage.SetEnemy(t);
		}
	}


}
